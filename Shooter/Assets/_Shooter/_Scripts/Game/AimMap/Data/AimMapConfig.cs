using UnityEngine;
using GlassyCode.Shooter.Core.Data;

namespace GlassyCode.Shooter.Game.AimMap.Data
{
    [CreateAssetMenu(menuName = "Configs/Aim Map Config", fileName = "Aim Map Config")]
    public class AimMapConfig : Config, IAimMapConfig
    {
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