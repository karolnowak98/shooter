using System;
using Zenject;
using GlassyCode.Shooter.Core.Time;
using GlassyCode.Shooter.Game.AimTraining.Data;
using GlassyCode.Shooter.Game.AimTraining.Logic.Interfaces;
using GlassyCode.Shooter.Game.Player.Logic;
using GlassyCode.Shooter.Game.Weapons.Logic.Interfaces;
using UnityEngine;

namespace GlassyCode.Shooter.Game.AimTraining.Logic
{
    public class AimTrainingManager : IAimTrainingManager, ITickable
    {
        private IShootingController _shootingController;
        private ICameraController _cameraController;
        
        public ITargetsController TargetsController { get; private set; }
        public ITimer PreparationTimer { get; private set; }
        public ITimer RoundTimer { get; private set; }
        
        public event Action OnFinishRound;

        [Inject]
        private void Construct(ITimeController timeController, ICameraController cameraController, 
            IShootingController shootingController, IAimTrainingConfig config, BoxCollider targetsSpawnArea, GameObject targetPrefab)
        {
            _shootingController = shootingController;
            _cameraController = cameraController;
            
            var preparationTimerData = config.PreparationTimer;
            var roundTimerData = config.RoundTimer;
            
            PreparationTimer = new PreparationTimer(timeController, preparationTimerData.CountdownTime, preparationTimerData.UIRefreshInterval);
            RoundTimer = new RoundTimer(cameraController, timeController, roundTimerData.CountdownTime, roundTimerData.UIRefreshInterval);
            TargetsController = new TargetsController(shootingController, targetsSpawnArea, targetPrefab);
        }

        public void Tick()
        {
            PreparationTimer.Tick();
            RoundTimer.Tick();
        }

        public void RestartRound()
        {
            ResetRound();
            StartPreparation();
        }
        
        public void StartPreparation()
        {
            _cameraController.ResetCamera();
            RoundTimer.OnTimerExpired += FinishRound;
            PreparationTimer.OnTimerExpired += StartRound;
            PreparationTimer.Restart();
        }

        private void ResetRound()
        {
            RoundTimer.OnTimerExpired -= FinishRound;
            PreparationTimer.OnTimerExpired -= StartRound;
            RoundTimer.Reset();
            PreparationTimer.Reset();
            TargetsController.ResetStats();
        }

        private void StartRound()
        {
            _cameraController.UnlockCamera();
            _shootingController.EnableShooting();
            RoundTimer.Restart();
            TargetsController.SpawnTargetAtRandomPosition();
        }

        private void FinishRound()
        {
            _cameraController.LockCamera();
            _shootingController.DisableShooting();
            OnFinishRound?.Invoke();
        }
    }
}