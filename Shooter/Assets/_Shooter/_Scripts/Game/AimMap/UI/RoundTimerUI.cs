using UnityEngine;
using TMPro;
using Zenject;
using GlassyCode.Shooter.Core.Time.UI;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.AimMap.Logic;

namespace GlassyCode.Shooter.Game.AimMap.UI
{
    public class RoundTimerUI : TimerUI
    {
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
            SetTimeLeftTmp(remainingTime);
            Show();
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