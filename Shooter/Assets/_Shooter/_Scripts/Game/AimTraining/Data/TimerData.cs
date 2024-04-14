using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace GlassyCode.Shooter.Game.AimTraining.Data
{
    [Serializable]
    public struct TimerData
    {
        [FormerlySerializedAs("_timeToCount")] [SerializeField, Tooltip("In seconds.")]
        private float _countdownTime;
        
        [SerializeField, Tooltip("In seconds.")]
        private float _uiRefreshInterval;
        
        public float CountdownTime => _countdownTime;
        public float UIRefreshInterval => _uiRefreshInterval;
    }
}