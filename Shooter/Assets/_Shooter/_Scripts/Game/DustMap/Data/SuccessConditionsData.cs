using System;
using UnityEngine;
using GlassyCode.Shooter.Core.Data.Quests;

namespace GlassyCode.Shooter.Game.DustMap.Data
{
    [Serializable]
    public struct SuccessConditionsData
    {
        [SerializeField] 
        private CounterConditionData _boxes;
        
        [SerializeField] 
        private CounterConditionData _jugs;

        [SerializeField] 
        private CounterConditionData _barrels;
        
        [SerializeField] 
        private CounterConditionData _bottles;
        
        [SerializeField] 
        private CounterConditionData _axes;
        
        public CounterConditionData Boxes => _boxes;
        public CounterConditionData Jugs => _jugs;
        public CounterConditionData Barrels => _barrels;
        public CounterConditionData Bottles => _bottles;
        public CounterConditionData Axes => _axes;
    }
}