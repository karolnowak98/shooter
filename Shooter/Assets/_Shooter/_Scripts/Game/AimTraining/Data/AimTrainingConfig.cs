using GlassyCode.Shooter.Core.Data;
using GlassyCode.Shooter.Game.AimTraining.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace GlassyCode.Shooter.Game.AimTraining.Data
{
    [CreateAssetMenu(menuName = "Configs/Aim Training Config", fileName = "Aim Training Config")]
    public class AimTrainingConfig : Config, IAimTrainingConfig
    {
        [SerializeField] private TimerData _preparationTimer;
        [SerializeField] private TimerData _roundTimer;

        public TimerData PreparationTimer => _preparationTimer;
        public TimerData RoundTimer => _roundTimer;
    }
}