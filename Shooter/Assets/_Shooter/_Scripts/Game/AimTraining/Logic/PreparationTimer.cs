using GlassyCode.Shooter.Core.Time;

namespace GlassyCode.Shooter.Game.AimTraining.Logic
{
    public sealed class PreparationTimer : Timer
    {
        public PreparationTimer(ITimeController timeController, float countdownTime, float refreshUIInterval) 
            : base(timeController, countdownTime, refreshUIInterval)
        {
        }
    }
}