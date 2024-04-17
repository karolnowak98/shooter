using System;
using GlassyCode.Shooter.Core.Data.Quests;
using UnityEngine;

namespace GlassyCode.Shooter.Game.AimMap.Data
{
    [Serializable]
    public struct RoundSuccessConditionsData
    {
        [SerializeField] private CounterConditionData _hitsConditionData;
        [SerializeField] private PercentageConditionData _accuracyConditionData;

        public CounterConditionData HitsConditionData => _hitsConditionData;
        public PercentageConditionData AccuracyConditionData => _accuracyConditionData;
    }
}