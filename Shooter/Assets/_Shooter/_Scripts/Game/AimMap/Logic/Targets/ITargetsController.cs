using System;

namespace GlassyCode.Shooter.Game.AimMap.Logic.Targets
{
    public interface ITargetsController
    {
        uint Hits{ get; }
        uint Misses{ get; }
        float Accuracy { get; }
        bool AreSuccessConditionsMet { get; }
        event Action<uint> OnHitsIncremented;
        event Action<uint> OnMissesIncremented;
        void Reset();
        void SpawnTargetAtRandomPosition();
    }
}