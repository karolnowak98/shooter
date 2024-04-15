using System;
using UnityEngine;
using GlassyCode.Shooter.Core.Data.Quests;

namespace GlassyCode.Shooter.Game.AimTraining.Data
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