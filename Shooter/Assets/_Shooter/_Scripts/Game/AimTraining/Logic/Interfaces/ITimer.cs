using System;

namespace GlassyCode.Shooter.Game.AimTraining.Logic.Interfaces
{
    public interface ITimer
    {
        event Action OnTimerReset;
        event Action OnTimerExpired;
        event Action<float> OnTimerStarted;
        event Action OnTimerStopped;
        event Action<float> OnUpdateUI;
        void Stop();
        void Reset();
        void Restart();
        void Tick();
    }
}