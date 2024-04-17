using System;
using GlassyCode.Shooter.Core.Time;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.Props.Enums;

namespace GlassyCode.Shooter.Game.DustMap.Logic
{
    public interface IDustMapManager
    {
        ITimer MissionTimer { get; }
        event Action OnMissionStarted;
        event Action<RoundResult> OnMissionFinished;
        event Action<PropName, uint> OnPropDestroyed;
        void RestartRound();
    }
}