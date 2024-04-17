using System;
using GlassyCode.Shooter.Core.Time;
using GlassyCode.Shooter.Game.AimMap.Data;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.AimMap.Logic.Targets;
using GlassyCode.Shooter.Game.AimMap.Logic.Timers;
using GlassyCode.Shooter.Game.Player.Logic;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Game.AimMap.Logic
{
    public sealed class AimMapManager : IAimMapManager, ITickable
    {
        private IPlayerController _playerController;
        
        public ITargetsController TargetsController { get; private set; }
        public ITimer PreparationTimer { get; private set; }
        public ITimer RoundTimer { get; private set; }
        
        public event Action<RoundResult> OnRoundFinished; // <roundResult>
        public event Action OnRoundPrepared; 

        [Inject]
        private void Construct(IAimMapConfig config, IPlayerController playerController, ITimeController timeController, BoxCollider targetsSpawnArea, GameObject targetPrefab)
        {
            var preparationTimerData = config.PreparationTimer;
            var roundTimerData = config.RoundTimer;

            _playerController = playerController;
            
            PreparationTimer = new PreparationTimer(timeController, preparationTimerData.CountdownTime, preparationTimerData.UIRefreshInterval);
            RoundTimer = new RoundTimer(_playerController.CameraController, timeController, roundTimerData.CountdownTime, roundTimerData.UIRefreshInterval);
            TargetsController = new TargetsController(_playerController.ShootingController, targetsSpawnArea, targetPrefab, config.SuccessConditionsDataData);
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
            _playerController.Reset();
        }
        
        private void StartPreparation()
        {
            RoundTimer.OnTimerExpired += FinishRound;
            PreparationTimer.OnTimerExpired += StartRound;
            PreparationTimer.Start();
        }

        private void StartRound()
        {
            _playerController.EnableControls();
            
            TargetsController.SpawnTargetAtRandomPosition();
            RoundTimer.Start();
            OnRoundPrepared?.Invoke();
        }

        private void FinishRound()
        {
            _playerController.DisableControls();

            OnRoundFinished?.Invoke(TargetsController.AreSuccessConditionsMet ? RoundResult.Success : RoundResult.Failure);
        }
    }
}