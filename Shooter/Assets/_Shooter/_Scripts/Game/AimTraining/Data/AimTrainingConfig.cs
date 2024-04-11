using GlassyCode.Shooter.Core.Data;
using UnityEngine;

namespace GlassyCode.Shooter.Game.AimTraining.Data
{
    [CreateAssetMenu(menuName = "Configs/Aim Training Config", fileName = "Aim Training Config")]
    public class AimTrainingConfig : Config, IAimTrainingConfig
    {
        [SerializeField, Tooltip("In seconds.")]
        private float _roundLength;
        
        [SerializeField, Tooltip("In seconds.")]
        private float _timerUIRefreshInterval;
        
        public float RoundLength => _roundLength;
        public float TimerUIRefreshInterval => _timerUIRefreshInterval;
    }
}