using Zenject;
using GlassyCode.Shooter.Core.Time.UI;
using GlassyCode.Shooter.Game.AimMap.Logic;

namespace GlassyCode.Shooter.Game.AimMap.UI
{
    public class PreparationTimerUI : TimerUI
    {
        private IAimMapManager _aimMapManager;
        
        [Inject]
        private void Construct(IAimMapManager aimMapManager)
        {
            _aimMapManager = aimMapManager;

            _aimMapManager.PreparationTimer.OnUpdateUI += SetTimeLeftTmp;
            _aimMapManager.PreparationTimer.OnTimerStarted += ResetPanel;
            _aimMapManager.OnRoundPrepared += Hide;
        }

        private void OnDestroy()
        {
            _aimMapManager.PreparationTimer.OnUpdateUI -= SetTimeLeftTmp;
            _aimMapManager.PreparationTimer.OnTimerStarted -= ResetPanel;
            _aimMapManager.OnRoundPrepared -= Hide;
        }

        private void ResetPanel(float remainingSeconds)
        {
            SetTimeLeftTmp(remainingSeconds);
            Show();
        }
    }
}