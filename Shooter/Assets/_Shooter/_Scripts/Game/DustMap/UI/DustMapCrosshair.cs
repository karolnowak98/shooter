using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.DustMap.Logic;

namespace GlassyCode.Shooter.Game.DustMap.UI
{
    public class DustMapCrosshair : Crosshair
    {
        private IDustMapManager _dustMapManager;
        
        [Inject]
        private void Construct(IDustMapManager dustMapManager)
        {
            _dustMapManager = dustMapManager;

            _dustMapManager.OnMissionStarted += Show;
            _dustMapManager.OnMissionFinished += Hide;
        }

        private void OnDestroy()
        {
            _dustMapManager.OnMissionStarted -= Show;
            _dustMapManager.OnMissionFinished -= Hide;
        }

        private void Hide(RoundResult obj)
        {
            Hide();
        }
    }
}