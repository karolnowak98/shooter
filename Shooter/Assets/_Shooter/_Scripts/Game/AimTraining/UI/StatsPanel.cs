using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimTraining.Logic.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Game.AimTraining.UI
{
    public class StatsPanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _hitsValueTmp;
        [SerializeField] private TextMeshProUGUI _missesValueTmp;
        [SerializeField] private TextMeshProUGUI _hitPercentTmp;
        
        private IAimTrainingManager _aimTrainingManager;
        private ITargetsController _targetsController;
        
        [Inject]
        private void Construct(IAimTrainingManager aimTrainingManager)
        {
            _aimTrainingManager = aimTrainingManager;
            _targetsController = _aimTrainingManager.TargetsController;

            _aimTrainingManager.RoundTimer.OnTimerExpired += ShowPanel;
        }

        private void OnDestroy()
        {
            _aimTrainingManager.RoundTimer.OnTimerExpired -= ShowPanel;
        }

        private void ShowPanel()
        {
            _hitsValueTmp.text = $"{_targetsController.Hits}";
            _missesValueTmp.text = $"{_targetsController.Misses}";
            _hitPercentTmp.text = $"{_targetsController.Accuracy:N2}%";
            Show();
        }
    }
}