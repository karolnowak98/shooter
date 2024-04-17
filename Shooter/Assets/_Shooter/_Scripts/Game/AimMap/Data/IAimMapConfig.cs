namespace GlassyCode.Shooter.Game.AimMap.Data
{
    public interface IAimMapConfig
    {
        TimerData PreparationTimer { get; }
        TimerData RoundTimer { get; }
        RoundSuccessConditionsData SuccessConditionsDataData { get; }
    }
}