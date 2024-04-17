using UnityEngine;
using GlassyCode.Shooter.Core.Input;
using GlassyCode.Shooter.Game.Player.Data;

namespace GlassyCode.Shooter.Game.Player.Logic.Movement
{
    public sealed class MovementController : IMovementController
    {
        private readonly IInputManager _inputManager;
        private readonly Rigidbody _rb;
        private readonly Transform _orientation;
        private readonly Transform _player;
        
        private MovementData _movementData;
        private Vector3 _moveDirection;
        private bool _isGrounded;
        private bool _canMove;
        private bool _canJump;
        private float _nextJumpTime;

        public MovementController(IInputManager inputManager, Transform player,  Rigidbody rb, Transform orientation, MovementData data)
        {
            _inputManager = inputManager;
            _player = player;
            _rb = rb;
            _orientation = orientation;
            _movementData = data;
        }
        
        public void Dispose()
        {
            DisableMovement();
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
            if (!_canMove) return;
            
            AddMoveForce();
        }

        public void EnableMovement()
        {
            _inputManager.OnSpacePressed += Jump;
            _canMove = true;
        }

        public void DisableMovement()
        {
            _inputManager.OnSpacePressed -= Jump;
            _canMove = false;
        }

        private void GetInput()
        {
            _moveDirection = _orientation.forward * _inputManager.MoveAxis.y + _orientation.right * _inputManager.MoveAxis.x;
        }

        private void AddDragForce()
        {
            _isGrounded = Physics.Raycast(_orientation.position, Vector3.down, _movementData.PlayerHeight * 0.51f, _movementData.GroundMask);
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
                _rb.AddForce(_player.up * _movementData.JumpForce, ForceMode.Impulse);
                _nextJumpTime = Time.time + _movementData.JumpCooldown;
            }
        }
    }
}
