using UnityEngine;
using GlassyCode.Shooter.Core.Data;

namespace GlassyCode.Shooter.Game.AimTraining.Data
{
    [CreateAssetMenu(menuName = "Configs/Aim Training Config", fileName = "Aim Training Config")]
    public class AimTrainingConfig : Config, IAimTrainingConfig
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