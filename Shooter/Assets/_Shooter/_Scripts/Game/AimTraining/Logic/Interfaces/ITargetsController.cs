using System;

namespace GlassyCode.Shooter.Game.AimTraining.Logic.Interfaces
{
    public interface ITargetsController
    {
        uint Hits{ get; }
        uint Misses{ get; }
        float Accuracy { get; }
        event Action<uint> OnHitsIncremented;
        event Action<uint> OnMissesIncremented;
        void ResetStats();
        void SpawnTargetAtRandomPosition();
    }
}