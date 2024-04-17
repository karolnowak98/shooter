using GlassyCode.Shooter.Core.Time;
using GlassyCode.Shooter.Core.Time.Logic;

namespace GlassyCode.Shooter.Game.AimMap.Logic.Timers
{
    public sealed class PreparationTimer : Timer
    {
        public PreparationTimer(ITimeController timeController, float countdownTime, float refreshUIInterval) 
            : base(timeController, countdownTime, refreshUIInterval)
        {
        }
    }
}