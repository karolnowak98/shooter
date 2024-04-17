using UnityEngine;
using TMPro;
using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.DustMap.Logic;

namespace GlassyCode.Shooter.Game.DustMap.UI
{
    public class MissionTimerUI : Panel
    {
        [SerializeField] private TextMeshProUGUI _timeLeftTmp;
        
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
            _timeLeftTmp.text = $"{remainingTime:N1}";
            Show();
        }

        private void SetTimeLeftTmp(float seconds)
        {
            _timeLeftTmp.text = $"{seconds:N1}";
        }
    }
}