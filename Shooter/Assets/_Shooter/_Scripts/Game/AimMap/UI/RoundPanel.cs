using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.AimMap.Logic;
using TMPro;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Game.AimMap.UI
{
    public class RoundPanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _timeLeftTmp;
        [SerializeField] private TextMeshProUGUI _hitsTmp;
        [SerializeField] private TextMeshProUGUI _missesTmp;
        
        private IAimMapManager _aimMapManager;
        
        [Inject]
        private void Construct(IAimMapManager aimMapManager)
        {
            _aimMapManager = aimMapManager;
            
            _aimMapManager.RoundTimer.OnTimerStarted += ResetPanel;
            _aimMapManager.RoundTimer.OnUpdateUI += SetTimeLeftTmp;
            _aimMapManager.OnRoundFinished += Hide;
            _aimMapManager.TargetsController.OnHitsIncremented += SetHitsTmp;
            _aimMapManager.TargetsController.OnMissesIncremented += SetMissesTmp;
        }

        private void OnDestroy()
        {
            _aimMapManager.RoundTimer.OnTimerStarted -= ResetPanel;
            _aimMapManager.RoundTimer.OnUpdateUI -= SetTimeLeftTmp;
            _aimMapManager.OnRoundFinished -= Hide;
            _aimMapManager.TargetsController.OnHitsIncremented -= SetHitsTmp;
            _aimMapManager.TargetsController.OnMissesIncremented -= SetMissesTmp;
        }

        private void Hide(RoundResult obj)
        {
            Hide();
        }

        private void ResetPanel(float remainingTime)
        {
            _hitsTmp.text = "0";
            _missesTmp.text = "0";
            _timeLeftTmp.text = $"{remainingTime:N1}";
            Show();
        }

        private void SetTimeLeftTmp(float seconds)
        {
            _timeLeftTmp.text = $"{seconds:N1}";
        }

        private void SetHitsTmp(uint hits)
        {
            _hitsTmp.text = $"{hits}";
        }
        
        private void SetMissesTmp(uint misses)
        {
            _missesTmp.text = $"{misses}";
        }
    }
}