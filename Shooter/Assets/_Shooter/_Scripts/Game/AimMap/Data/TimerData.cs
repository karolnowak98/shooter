using System;
using UnityEngine;

namespace GlassyCode.Shooter.Game.AimMap.Data
{
    [Serializable]
    public struct TimerData
    {
        [Tooltip("In seconds.")]
        [SerializeField, Min(0)]
        private float _countdownTime;
        
        [Tooltip("In seconds.")]
        [SerializeField, Min(0)]
        private float _uiRefreshInterval;
        
        public float CountdownTime => _countdownTime;
        public float UIRefreshInterval => _uiRefreshInterval;
    }
}