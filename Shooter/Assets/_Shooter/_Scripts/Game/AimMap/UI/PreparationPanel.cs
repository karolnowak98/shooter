using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimMap.Logic;
using TMPro;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Game.AimMap.UI
{
    public class PreparationPanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _countingDownTmp;

        private IAimMapManager _aimMapManager;
        
        [Inject]
        private void Construct(IAimMapManager aimMapManager)
        {
            _aimMapManager = aimMapManager;

            _aimMapManager.PreparationTimer.OnUpdateUI += SetCountingDownTmp;
            _aimMapManager.PreparationTimer.OnTimerStarted += ResetPanel;
            _aimMapManager.OnRoundPrepared += Hide;
        }

        private void OnDestroy()
        {
            _aimMapManager.PreparationTimer.OnUpdateUI -= SetCountingDownTmp;
            _aimMapManager.PreparationTimer.OnTimerStarted -= ResetPanel;
            _aimMapManager.OnRoundPrepared -= Hide;
        }

        private void ResetPanel(float remainingSeconds)
        {
            _countingDownTmp.text = $"{remainingSeconds:N0}";
            Show();
        }
        
        private void SetCountingDownTmp(float seconds)
        {
            _countingDownTmp.text = $"{seconds:N0}";
        }
    }
}