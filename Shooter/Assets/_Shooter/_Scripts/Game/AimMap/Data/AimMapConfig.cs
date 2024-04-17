using GlassyCode.Shooter.Core.Data;
using UnityEngine;

namespace GlassyCode.Shooter.Game.AimMap.Data
{
    [CreateAssetMenu(menuName = "Configs/Aim Training Config", fileName = "Aim Training Config")]
    public class AimMapConfig : Config, IAimMapConfig
    {
        //Might be better to use I2Loc for example
        
        
        [Tooltip("Timer for the preparation phase.")]
        [SerializeField]
        private TimerData _preparationTimer;

        [Tooltip("Timer for each round.")]
        [SerializeField]
        private TimerData _roundTimer;

        [SerializeField] 
        private RoundSuccessConditionsData _successConditionsDataData;

        public TimerData PreparationTimer => _preparationTimer;
        public TimerData RoundTimer => _roundTimer;
        public RoundSuccessConditionsData SuccessConditionsDataData => _successConditionsDataData;
    }
}