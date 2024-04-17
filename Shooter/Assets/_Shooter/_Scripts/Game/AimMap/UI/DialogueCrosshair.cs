using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.AimMap.Logic;

namespace GlassyCode.Shooter.Game.AimMap.UI
{
    public class DialogueCrosshair : Crosshair
    {
        private IAimMapManager _aimMapManager;
        
        [Inject]
        private void Construct(IAimMapManager aimMapManager)
        {
            _aimMapManager = aimMapManager;

            _aimMapManager.OnRoundPrepared += Show;
            _aimMapManager.OnRoundFinished += Hide;
        }

        private void OnDestroy()
        {
            _aimMapManager.OnRoundPrepared -= Show;
            _aimMapManager.OnRoundFinished -= Hide;
        }

        private void Hide(RoundResult obj)
        {
            Hide();
        }
    }
}