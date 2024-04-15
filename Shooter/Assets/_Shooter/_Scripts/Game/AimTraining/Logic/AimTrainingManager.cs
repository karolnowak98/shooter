using System;
using UnityEngine;
using Zenject;
using GlassyCode.Shooter.Core.Time;
using GlassyCode.Shooter.Game.AimTraining.Data;
using GlassyCode.Shooter.Game.AimTraining.Enums;
using GlassyCode.Shooter.Game.AimTraining.Logic.Targets;
using GlassyCode.Shooter.Game.AimTraining.Logic.Timers;
using GlassyCode.Shooter.Game.Player.Logic.Cameras;
using GlassyCode.Shooter.Game.Player.Logic.Movement;
using GlassyCode.Shooter.Game.Weapons.Logic;
using GlassyCode.Shooter.Game.Weapons.Logic.Shooting;

namespace GlassyCode.Shooter.Game.AimTraining.Logic
{
    public class AimTrainingManager : IAimTrainingManager, ITickable
    {
        private IShootingController _shootingController;
        private ICameraController _cameraController;
        private IMovementController _movementController;
        
        public ITargetsController TargetsController { get; private set; }
        public ITimer PreparationTimer { get; private set; }
        public ITimer RoundTimer { get; private set; }
        
        public event Action<RoundResult> OnRoundFinished; // <roundResult>
        public event Action OnRoundPrepared; 

        [Inject]
        private void Construct(ITimeController timeController, ICameraController cameraController, IMovementController movementController,
            IShootingController shootingController, IAimTrainingConfig config, BoxCollider targetsSpawnArea, GameObject targetPrefab)
        {
            var preparationTimerData = config.PreparationTimer;
            var roundTimerData = config.RoundTimer;
            
            _shootingController = shootingController;
            _cameraController = cameraController;
            _movementController = movementController;
            
            PreparationTimer = new PreparationTimer(timeController, preparationTimerData.CountdownTime, preparationTimerData.UIRefreshInterval);
            RoundTimer = new RoundTimer(cameraController, timeController, roundTimerData.CountdownTime, roundTimerData.UIRefreshInterval);
            TargetsController = new TargetsController(shootingController, targetsSpawnArea, targetPrefab, config.SuccessConditionsDataData);
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
        
        private void ResetRound()
        {
            RoundTimer.Reset();
            PreparationTimer.Reset();
            TargetsController.Reset();
            _cameraController.ResetCamera();
            RoundTimer.OnTimerExpired -= FinishRound;
            PreparationTimer.OnTimerExpired -= StartRound;
        }
        
        private void StartPreparation()
        {
            RoundTimer.OnTimerExpired += FinishRound;
            PreparationTimer.OnTimerExpired += StartRound;
            PreparationTimer.Restart();
            OnRoundPrepared?.Invoke();
        }

        private void StartRound()
        {
            _movementController.EnableMovement();
            _cameraController.UnlockCamera();
            _shootingController.EnableShooting();
            
            TargetsController.SpawnTargetAtRandomPosition();
            RoundTimer.Restart();
            OnRoundPrepared?.Invoke();
        }

        private void FinishRound()
        {
            _movementController.DisableMovement();
            _cameraController.LockCamera();
            _shootingController.DisableShooting();

            OnRoundFinished?.Invoke(TargetsController.AreSuccessConditionsMet ? RoundResult.Success : RoundResult.Failure);
        }
    }
}