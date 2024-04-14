using Zenject;
using GlassyCode.Shooter.Core.UI;
using GlassyCode.Shooter.Game.AimTraining.Logic.Interfaces;

namespace GlassyCode.Shooter.Game.AimTraining.UI
{
    public class ScoresPanel : Panel
    {
        private IAimTrainingManager _aimTrainingManager;
        
        [Inject]
        private void Construct(IAimTrainingManager aimTrainingManager)
        {
            _aimTrainingManager = aimTrainingManager;

            _aimTrainingManager.RoundTimer.OnTimerExpired += Show;
        }

        private void OnDestroy()
        {
            _aimTrainingManager.RoundTimer.OnTimerExpired -= Show;
        }
    }
}