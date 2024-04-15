using System;
using GlassyCode.Shooter.Core.Input;
using GlassyCode.Shooter.Game.Player.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Game.Player.Logic.Movement
{
    public class MovementController : IMovementController, IInitializable, ITickable, IFixedTickable, IDisposable
    {
        private IInputManager _inputManager;
        private MovementData _movementData;
        private Rigidbody _rb;
        private Transform _orientation;
        private Vector3 _moveDirection;
        private bool _isGrounded;
        private bool _canMove;
        private bool _canJump;
        private float _nextJumpTime;

        public Transform Player { get; private set; }

        [Inject]
        private void Construct(IInputManager inputManager, MovementData data, Transform orientation, Transform playerTransform, Rigidbody rb)
        {
            _inputManager = inputManager;
            _movementData = data;
            _orientation = orientation;
            Player = playerTransform;
            _rb = rb;

            _inputManager.OnSpacePressed += Jump;
        }
        
        public void Dispose()
        {
            _inputManager.OnSpacePressed -= Jump;
        }
        
        public void Initialize()
        {
            _rb.freezeRotation = true;
        }

        public void Tick()
        {
            if (!_canMove) return;
            
            GetInput();
            AddDragForce();
            LimitMoveSpeed();
            CalculateAirCooldown();
        }

        public void FixedTick()
        {
            AddMoveForce();
        }

        public void EnableMovement()
        {
            _canMove = true;
        }

        public void DisableMovement()
        {
            _canMove = false;
        }

        private void GetInput()
        {
            _moveDirection = _orientation.forward * _inputManager.MoveAxis.y + _orientation.right * _inputManager.MoveAxis.x;
        }

        private void AddDragForce()
        {
            _isGrounded = Physics.Raycast(_orientation.position, Vector3.down, _movementData.PlayerHeight * 0.5f, _movementData.GroundMask);
            _rb.drag = _isGrounded ? _movementData.DragForce : 0;
        }

        private void LimitMoveSpeed()
        {
            var velocity = _rb.velocity;
            var flatVelocity = new Vector3(velocity.x, 0f, velocity.z);

            if (flatVelocity.magnitude > _movementData.MaxMoveSpeed)
            {
                var limitedVelocity = flatVelocity.normalized * _movementData.MaxMoveSpeed;
                _rb.velocity = new Vector3(limitedVelocity.x, _rb.velocity.y, limitedVelocity.z);
            }
        }

        private void CalculateAirCooldown()
        {
            if (_canJump) return;
            
            if (Time.time > _nextJumpTime)
            {
                _canJump = true;
            }
        }

        private void AddMoveForce()
        {
            var moveSpeed = _isGrounded ? _movementData.MoveSpeed : _movementData.MoveSpeed * _movementData.AirMultiplier;
            _rb.AddForce(_moveDirection.normalized * moveSpeed, ForceMode.Force);
        }

        private void Jump()
        {
            if (_canJump && _isGrounded)
            {
                _canJump = false;
                
                var velocity = _rb.velocity;
                velocity = new Vector3(velocity.x, 0f, velocity.z);
                
                _rb.velocity = velocity;
                _rb.AddForce(Player.up * _movementData.JumpForce, ForceMode.Impulse);
                _nextJumpTime = Time.time + _movementData.JumpCooldown;
            }
        }
    }
}
