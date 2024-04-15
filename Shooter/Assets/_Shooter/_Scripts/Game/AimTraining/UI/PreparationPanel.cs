using UnityEngine;
using TMPro;
using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimTraining.Logic;

namespace GlassyCode.Shooter.Game.AimTraining.UI
{
    public class PreparationPanel : Panel
    {
        [SerializeField] private TextMeshProUGUI _countingDownTmp;

        private IAimTrainingManager _aimTrainingManager;
        
        [Inject]
        private void Construct(IAimTrainingManager aimTrainingManager)
        {
            _aimTrainingManager = aimTrainingManager;

            _aimTrainingManager.PreparationTimer.OnUpdateUI += SetCountingDownTmp;
            _aimTrainingManager.PreparationTimer.OnTimerStarted += ResetPanel;
            _aimTrainingManager.PreparationTimer.OnTimerExpired += Hide;
        }

        private void OnDestroy()
        {
            _aimTrainingManager.PreparationTimer.OnUpdateUI -= SetCountingDownTmp;
            _aimTrainingManager.PreparationTimer.OnTimerStarted -= ResetPanel;
            _aimTrainingManager.PreparationTimer.OnTimerExpired -= Hide;
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