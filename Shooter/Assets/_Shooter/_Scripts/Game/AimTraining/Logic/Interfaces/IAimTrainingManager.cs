using System;

namespace GlassyCode.Shooter.Game.AimTraining.Logic.Interfaces
{
    public interface IAimTrainingManager
    {
        ITargetsController TargetsController { get; }
        public ITimer PreparationTimer { get; }
        public ITimer RoundTimer { get; }
        event Action OnFinishRound;
        void StartPreparation();
    }
}