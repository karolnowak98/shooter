using System;
using GlassyCode.Shooter.Core.Time;

namespace GlassyCode.Shooter.Game.AimTraining.Logic.Timers
{
    public abstract class Timer : ITimer
    {
        private readonly ITimeController _timeController;
        private readonly float _countdownTime;
        private readonly float _refreshUIInterval;
        
        private bool _isRunning;
        private float _remainingTime;
        private float _elapsedTimeSinceUIUpdate;
        
        public event Action OnTimerReset;
        public event Action<float> OnTimerStarted;
        public event Action OnTimerStopped;
        public event Action OnTimerExpired;
        public event Action<float> OnUpdateUI;

        protected Timer(ITimeController timeController, float countdownTime, float refreshUIInterval)
        {
            _timeController = timeController;
            _countdownTime = countdownTime;
            _refreshUIInterval = refreshUIInterval;
        }

        public void Tick()
        {
            if (!_isRunning) return;
            
            var deltaTime = _timeController.DeltaTime;

            _remainingTime -= deltaTime;
            _elapsedTimeSinceUIUpdate += deltaTime;

            if (_elapsedTimeSinceUIUpdate >= _refreshUIInterval)
            {
                OnUpdateUI?.Invoke(_remainingTime);
                _elapsedTimeSinceUIUpdate = 0;
            }

            if (_remainingTime <= 0f)
            {
                Stop();
                OnTimerExpired?.Invoke();
            }
        }
        
        public virtual void Start()
        {
            _isRunning = true;
            OnTimerStarted?.Invoke(_remainingTime);
        }
        
        public virtual void Stop()
        {
            _isRunning = false;
            OnTimerStopped?.Invoke();
        }

        public virtual void Reset()
        {
            _isRunning = false;
            _remainingTime = _countdownTime;
            _elapsedTimeSinceUIUpdate = 0;
            OnTimerReset?.Invoke();
        }

        public virtual void Restart()
        {
            Reset();
            Start();
        }
    }
}