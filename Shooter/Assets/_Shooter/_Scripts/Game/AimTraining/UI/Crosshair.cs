using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimTraining.Logic;

namespace GlassyCode.Shooter.Game.AimTraining.UI
{
    public class Crosshair : Panel
    {
        private IAimTrainingManager _aimTrainingManager;
        
        [Inject]
        private void Construct(IAimTrainingManager aimTrainingManager)
        {
            _aimTrainingManager = aimTrainingManager;

            _aimTrainingManager.PreparationTimer.OnTimerExpired += Show;
            _aimTrainingManager.RoundTimer.OnTimerExpired += Hide;
        }

        private void OnDestroy()
        {
            _aimTrainingManager.PreparationTimer.OnTimerExpired -= Show;
            _aimTrainingManager.RoundTimer.OnTimerExpired -= Hide;
        }
    }
}