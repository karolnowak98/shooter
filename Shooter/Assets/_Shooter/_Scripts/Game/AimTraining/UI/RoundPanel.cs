using UnityEngine;
using TMPro;
using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimTraining.Logic.Interfaces;

namespace GlassyCode.Shooter.Game.AimTraining.UI
{
    public class RoundPanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _timeLeftTmp;
        [SerializeField] private TextMeshProUGUI _hitsTmp;
        [SerializeField] private TextMeshProUGUI _missesTmp;
        
        private IAimTrainingManager _aimTrainingManager;
        
        [Inject]
        private void Construct(IAimTrainingManager aimTrainingManager)
        {
            _aimTrainingManager = aimTrainingManager;
            
            _aimTrainingManager.RoundTimer.OnTimerStarted += ResetPanel;
            _aimTrainingManager.RoundTimer.OnUpdateUI += SetTimeLeftTmp;
            _aimTrainingManager.RoundTimer.OnTimerExpired += Hide;
            _aimTrainingManager.TargetsController.OnHitsIncremented += SetHitsTmp;
            _aimTrainingManager.TargetsController.OnMissesIncremented += SetMissesTmp;
        }

        private void OnDestroy()
        {
            _aimTrainingManager.RoundTimer.OnTimerStarted -= ResetPanel;
            _aimTrainingManager.RoundTimer.OnUpdateUI -= SetTimeLeftTmp;
            _aimTrainingManager.RoundTimer.OnTimerExpired -= Hide;
            _aimTrainingManager.TargetsController.OnHitsIncremented -= SetHitsTmp;
            _aimTrainingManager.TargetsController.OnMissesIncremented -= SetMissesTmp;
        }

        private void ResetPanel(float remainingTime)
        {
            _hitsTmp.text = "0";
            _missesTmp.text = "0";
            _timeLeftTmp.text = remainingTime.ToString("0.0");
            Show();
        }

        private void SetTimeLeftTmp(float seconds)
        {
            _timeLeftTmp.text = seconds.ToString("0.0");
        }

        private void SetHitsTmp(uint hits)
        {
            _hitsTmp.text = hits.ToString();
        }
        
        private void SetMissesTmp(uint misses)
        {
            _missesTmp.text = misses.ToString();
        }
    }
}