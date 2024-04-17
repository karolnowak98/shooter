using System;
using GlassyCode.Shooter.Core.Time.Logic;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.AimMap.Logic.Targets;

namespace GlassyCode.Shooter.Game.AimMap.Logic
{
    public interface IAimMapManager
    {
        ITargetsController TargetsController { get; }
        public ITimer PreparationTimer { get; }
        public ITimer RoundTimer { get; }
        event Action<RoundResult> OnRoundFinished;
        event Action OnRoundPrepared;
        void RestartRound();
    }
}