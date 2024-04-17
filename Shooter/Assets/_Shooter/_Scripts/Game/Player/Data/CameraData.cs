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

        public float XSens => _xSens;
        public float YSens => _ySens;
        public float MinYAngle => _minYAngle;
        public float MaxYAngle => _maxYAngle;
    }
}