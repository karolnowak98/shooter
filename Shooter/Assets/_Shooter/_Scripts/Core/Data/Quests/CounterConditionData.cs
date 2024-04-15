using System;
using UnityEngine;

namespace GlassyCode.Shooter.Core.Data.Quests
{
    [Serializable]
    public struct CounterConditionData
    {
        [SerializeField, Min(0)] 
        private uint _counter;
        
        [SerializeField]
        private string _uiLabel;
        
        public uint Counter => _counter;
        public string UILabel => _uiLabel;
    }
}