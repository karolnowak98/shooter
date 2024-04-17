using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.AimMap.Logic;
using GlassyCode.Shooter.Game.AimMap.Logic.Targets;
using TMPro;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Game.AimMap.UI
{
    public class StatsPanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _hitsValueTmp;
        [SerializeField] private TextMeshProUGUI _missesValueTmp;
        [SerializeField] private TextMeshProUGUI _hitPercentTmp;
        
        private IAimMapManager _aimMapManager;
        private ITargetsController _targetsController;
        
        [Inject]
        private void Construct(IAimMapManager aimMapManager)
        {
            _aimMapManager = aimMapManager;
            _targetsController = _aimMapManager.TargetsController;

            _aimMapManager.OnRoundFinished += ShowPanel;
            _aimMapManager.PreparationTimer.OnTimerStarted += Hide;
        }

        private void Hide(float obj)
        {
            Hide();
        }

        private void OnDestroy()
        {
            _aimMapManager.OnRoundFinished -= ShowPanel;
            _aimMapManager.PreparationTimer.OnTimerStarted -= Hide;
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