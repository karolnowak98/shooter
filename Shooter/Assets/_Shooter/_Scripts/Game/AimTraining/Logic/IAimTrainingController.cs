using System;

namespace GlassyCode.Shooter.Game.AimTraining.Logic
{
    public interface IAimTrainingController
    {
        event Action<float> OnUpdateTimer;
        event Action OnRoundStarted;
        event Action OnRoundFinished;
        void StartRound();
        void StopRound();
    }
}