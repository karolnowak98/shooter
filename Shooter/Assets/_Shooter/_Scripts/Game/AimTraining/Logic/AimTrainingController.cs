using System;
using Zenject;
using GlassyCode.Shooter.Core.Time;
using GlassyCode.Shooter.Game.AimTraining.Data;
using GlassyCode.Shooter.Game.Player.Logic;

namespace GlassyCode.Shooter.Game.AimTraining.Logic
{
    public class AimTrainingController : IAimTrainingController, ITickable
    {
        private ITimeController _timeController;
        private ICameraController _cameraController;

        private bool _isRoundRunning;
        private float _remainingTime;
        private float _elapsedTimeSinceUIUpdate;
        private float _roundLength;
        private float _timerUIRefreshInterval;

        public event Action OnRoundStarted;
        public event Action OnRoundFinished;
        public event Action<float> OnUpdateTimer;
        
        [Inject]
        private void Construct(ITimeController timeController, ICameraController cameraController, IAimTrainingConfig config)
        {
            _timeController = timeController;
            _cameraController = cameraController;
            
            _roundLength = config.RoundLength;
            _timerUIRefreshInterval = config.TimerUIRefreshInterval;
        }
        
        public void Tick()
        {
            if (!_isRoundRunning) return;
            
            _remainingTime -= _timeController.DeltaTime;

            if (_elapsedTimeSinceUIUpdate >= _timerUIRefreshInterval)
            {
                OnUpdateTimer?.Invoke(_remainingTime);
            }

            if (_remainingTime <= 0f)
            {
                StopRound();
            }
        }

        public void StartRound()
        {
            _remainingTime = _roundLength;
            _isRoundRunning = true;
            _cameraController.UnlockCamera();
            OnRoundStarted?.Invoke();
        }

        public void StopRound()
        {
            _isRoundRunning = false;
            _cameraController.LockCamera();
            OnRoundFinished?.Invoke();
        }
    }
}