using System;
using UnityEngine;

namespace GlassyCode.Shooter.Core.Data.Quests
{
    [Serializable]
    public struct PercentageConditionData
    {
        [Tooltip("In percentage (0 to 100).")]
        [SerializeField, Range(0, 100)]
        private float _percentage;
        
        public float Percentage => _percentage;
    }
}