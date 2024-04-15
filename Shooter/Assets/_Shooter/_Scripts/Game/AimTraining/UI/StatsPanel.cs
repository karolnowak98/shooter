using UnityEngine;
using TMPro;
using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimTraining.Data;
using GlassyCode.Shooter.Game.AimTraining.Enums;
using GlassyCode.Shooter.Game.AimTraining.Logic;
using GlassyCode.Shooter.Game.AimTraining.Logic.Targets;

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

            _aimTrainingManager.OnRoundFinished += ShowPanel;
            _aimTrainingManager.OnRoundPrepared += Hide;
        }

        private void OnDestroy()
        {
            _aimTrainingManager.OnRoundFinished -= ShowPanel;
            _aimTrainingManager.OnRoundPrepared -= Hide;
        }

        private void ShowPanel(RoundResult _)
        {
            _hitsValueTmp.text = $"{_targetsController.Hits}";
            _missesValueTmp.text = $"{_targetsController.Misses}";
            _hitPercentTmp.text = $"{_targetsController.Accuracy:N2}%";
            Show();
        }
    }
}