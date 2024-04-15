namespace GlassyCode.Shooter.Game.AimTraining.Data
{
    public interface IAimTrainingConfig
    {
        TimerData PreparationTimer { get; }
        TimerData RoundTimer { get; }
        RoundSuccessConditionsData SuccessConditionsDataData { get; }
    }
}