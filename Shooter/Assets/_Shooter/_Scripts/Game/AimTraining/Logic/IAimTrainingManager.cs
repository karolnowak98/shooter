using System;
using GlassyCode.Shooter.Game.AimTraining.Data;
using GlassyCode.Shooter.Game.AimTraining.Enums;
using GlassyCode.Shooter.Game.AimTraining.Logic.Targets;
using GlassyCode.Shooter.Game.AimTraining.Logic.Timers;

namespace GlassyCode.Shooter.Game.AimTraining.Logic
{
    public interface IAimTrainingManager
    {
        ITargetsController TargetsController { get; }
        public ITimer PreparationTimer { get; }
        public ITimer RoundTimer { get; }
        event Action<RoundResult> OnRoundFinished;
        event Action OnRoundPrepared;
        void RestartRound();
    }
}