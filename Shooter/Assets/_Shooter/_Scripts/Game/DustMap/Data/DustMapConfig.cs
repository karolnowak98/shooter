using UnityEngine;
using GlassyCode.Shooter.Core.Data;
using GlassyCode.Shooter.Game.AimMap.Data;

namespace GlassyCode.Shooter.Game.DustMap.Data
{
    [CreateAssetMenu(fileName = "Dust Map Config", menuName = "Configs/Dust Map Config")]
    public class DustMapConfig : Config, IDustMapConfig
    {
        [SerializeField] 
        private SuccessConditionsData _successConditionsData;

        [SerializeField] 
        private TimerData _roundTimer;
        
        public SuccessConditionsData SuccessConditionsData => _successConditionsData;
        public TimerData RoundTimer => _roundTimer;
    }
}