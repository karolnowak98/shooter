using System;

namespace GlassyCode.Shooter.Core.Time.Logic
{
    public interface ITimer
    {
        event Action OnTimerReset;
        event Action OnTimerExpired;
        event Action<float> OnTimerStarted;
        event Action OnTimerStopped;
        event Action<float> OnUpdateUI;
        void Tick();
        void Start();
        void Stop();
        void Reset();
    }
}