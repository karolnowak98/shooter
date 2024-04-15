using GlassyCode.Shooter.Core.Cursors;
using GlassyCode.Shooter.Game.Player.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace GlassyCode.Shooter.Game.Player.Logic.Cameras
{
    public class CameraController : ICameraController, IInitializable, ITickable
    {
        private ICursorController _cursorController;
        private CameraData _data;
        private Transform _holder;
        private Transform _playerCameraPosition;
        private Transform _playerOrientation;
        private float _xRotation;
        private float _yRotation;
        private bool _isCameraUnlocked;

        [Inject]
        private void Construct(ICursorController cursorController, CameraData data, Transform transform, 
            Transform playerCameraPosition, Transform playerOrientation)
        {
            _cursorController = cursorController;
            _data = data;
            _holder = transform;
            _playerCameraPosition = playerCameraPosition;
            _playerOrientation = playerOrientation;
        }
        
        public void Initialize()
        {
            ResetCamera();
        }
        
        public void Tick()
        {
            if (!_isCameraUnlocked) return;
            
            CalculateRotation();
            UpdateCameraTransform();
        }
        
        public void LockCamera()
        {
            _isCameraUnlocked = false;
            _cursorController.UnlockCursor();
        }

        public void UnlockCamera()
        {
            _cursorController.LockCursor();
            _isCameraUnlocked = true;
        }

        public void ResetCamera()
        {
            var startingRotation = _data.StartingRotation;

            _yRotation = startingRotation.y;
            _xRotation = startingRotation.x;
            
            UpdateCameraTransform();
        }

        private void CalculateRotation()
        {
            var mouseDelta = Mouse.current.delta.ReadValue();
            var mouseX = mouseDelta.x * Time.deltaTime * _data.XSens;
            var mouseY = mouseDelta.y * Time.deltaTime * _data.YSens;
            
            _yRotation += mouseX;
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, _data.MinYAngle, _data.MaxYAngle);
        }

        private void UpdateCameraTransform()
        {
            _holder.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            _playerOrientation.rotation = Quaternion.Euler(0, _yRotation, 0);
            _holder.position = _playerCameraPosition.position;
        }
    }
}