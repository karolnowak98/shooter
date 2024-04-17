using Zenject;
using GlassyCode.Shooter.Core.Time.UI;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.DustMap.Logic;

namespace GlassyCode.Shooter.Game.DustMap.UI
{
    public class MissionTimerUI : TimerUI
    {
        private IDustMapManager _aimMapManager;
        
        [Inject]
        private void Construct(IDustMapManager aimMapManager)
        {
            _aimMapManager = aimMapManager;
            
            _aimMapManager.MissionTimer.OnTimerStarted += ResetPanel;
            _aimMapManager.MissionTimer.OnUpdateUI += SetTimeLeftTmp;
            _aimMapManager.OnMissionFinished += Hide;
        }

        private void OnDestroy()
        {
            _aimMapManager.MissionTimer.OnTimerStarted -= ResetPanel;
            _aimMapManager.MissionTimer.OnUpdateUI -= SetTimeLeftTmp;
            _aimMapManager.OnMissionFinished -= Hide;
        }

        private void Hide(RoundResult obj)
        {
            Hide();
        }

        private void ResetPanel(float remainingTime)
        {
            SetTimeLeftTmp(remainingTime);
            Show();
        }
    }
}