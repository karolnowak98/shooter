using GlassyCode.Shooter.Core.Time.Logic;

namespace GlassyCode.Shooter.Game.DustMap.Logic
{
    public class MissionTimer : Timer
    {
        public MissionTimer(ITimeController timeController, float countdownTime, float refreshUIInterval) 
            : base(timeController, countdownTime, refreshUIInterval)
        {
        }
    }
}