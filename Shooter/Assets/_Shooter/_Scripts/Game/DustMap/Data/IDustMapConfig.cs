using GlassyCode.Shooter.Game.AimMap.Data;

namespace GlassyCode.Shooter.Game.DustMap.Data
{
    public interface IDustMapConfig
    {
        SuccessConditionsData SuccessConditionsData { get; }
        TimerData RoundTimer { get; }
    }
}