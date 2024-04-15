using System;
using UnityEngine;

namespace GlassyCode.Shooter.Game.Player.Data
{
    [Serializable]
    public struct CameraData
    {
        [Header("Sensitivity")]
        [Tooltip("The horizontal sensitivity of the camera.")]
        [SerializeField]
        private float _xSens;

        [Tooltip("The vertical sensitivity of the camera.")]
        [SerializeField]
        private float _ySens;

        [Header("Angle Constraints")]
        [Tooltip("The minimum angle in the y-axis.")]
        [SerializeField]
        private float _minYAngle;

        [Tooltip("The maximum angle in the y-axis.")]
        [SerializeField]
        private float _maxYAngle;
        
        [Header("Transform")] 
        [SerializeField]
        private Vector3 _startingPosition;
        
        [SerializeField]
        private Vector3 _startingRotation;

        public float XSens => _xSens;
        public float YSens => _ySens;
        public float MinYAngle => _minYAngle;
        public float MaxYAngle => _maxYAngle;
        public Vector3 StartingPosition => _startingPosition;
        public Vector3 StartingRotation => _startingRotation;
    }
}