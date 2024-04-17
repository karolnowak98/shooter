using UnityEngine;
using UnityEngine.InputSystem;
using GlassyCode.Shooter.Core.Cursors;
using GlassyCode.Shooter.Game.Player.Data;

namespace GlassyCode.Shooter.Game.Player.Logic.Cameras
{
    public sealed class CameraController : ICameraController
    {
        private readonly ICursorController _cursorController;
        private readonly Transform _cameraHolder;
        private readonly Transform _playerCameraPosition;
        private readonly Transform _playerOrientation;
        
        private CameraData _data;
        private float _xRotation;
        private float _yRotation;
        private bool _isCameraUnlocked;

        public CameraController(ICursorController cursorController, Transform playerOrientation, 
            Transform playerCameraPosition, Transform cameraHolder, CameraData data)
        {
            _cursorController = cursorController;
            _playerOrientation = playerOrientation;
            _playerCameraPosition = playerCameraPosition;
            _cameraHolder = cameraHolder;
            _data = data;
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

        public void ResetCamera(Vector3 rotation)
        {
            _yRotation = rotation.y;
            _xRotation = rotation.x;
            
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
            _cameraHolder.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            _playerOrientation.rotation = Quaternion.Euler(0, _yRotation, 0);
            _cameraHolder.position = _playerCameraPosition.position;
        }
    }
}