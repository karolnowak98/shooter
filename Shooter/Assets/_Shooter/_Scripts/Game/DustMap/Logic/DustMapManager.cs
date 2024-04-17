using System;
using Zenject;
using System.Collections.Generic;
using GlassyCode.Shooter.Core.Time;
using GlassyCode.Shooter.Game.AimMap.Enums;
using GlassyCode.Shooter.Game.DustMap.Data;
using GlassyCode.Shooter.Game.Player.Logic;
using GlassyCode.Shooter.Game.Props.Enums;

namespace GlassyCode.Shooter.Game.DustMap.Logic
{
    public class DustMapManager : IDustMapManager, IDisposable, ITickable
    {
        private readonly Dictionary<PropName, uint> _propsDestroyed = new();
        
        private IPlayerController _playerController;
        private SuccessConditionsData _successConditionsData;
        
        public ITimer MissionTimer { get; private set; }

        public event Action OnMissionStarted;
        public event Action<RoundResult> OnMissionFinished;
        public event Action<PropName, uint> OnPropDestroyed; //<PropName, PropDestroyedNumberAfter>
        
        [Inject]
        private void Construct(IDustMapConfig config, IPlayerController playerController, ITimeController timeController)
        {
            var roundTimerData = config.RoundTimer;
            
            _playerController = playerController;
            _successConditionsData = config.SuccessConditionsData;
            MissionTimer = new MissionTimer(timeController, roundTimerData.CountdownTime, roundTimerData.UIRefreshInterval);
            
            _playerController.ShootingController.OnPropDestroyed += IncrementDestroyed;
        }
        
        public void Dispose()
        {
            _playerController.ShootingController.OnPropDestroyed -= IncrementDestroyed;
        }
        
        public void Tick()
        {
            MissionTimer.Tick();
        }

        public void RestartRound()
        {
            ResetRound();
            StartRound();
        }

        private void ResetRound()
        {
            MissionTimer.Reset();
            _playerController.Reset();
            ResetProps();
        }

        private void ResetProps()
        {
            _propsDestroyed.Clear();
            
            foreach (PropName propName in Enum.GetValues(typeof(PropName)))
            {
                _propsDestroyed[propName] = 0;
            }
        }

        private void StartRound()
        {
            MissionTimer.OnTimerExpired += FinishRound;
            _playerController.EnableControls();
            MissionTimer.Start();
            OnMissionStarted?.Invoke();
        }

        private void FinishRound()
        {
            _playerController.DisableControls();
            OnMissionFinished?.Invoke(AreSuccessConditionsMet() ? RoundResult.Success : RoundResult.Failure);
        }
        
        private void IncrementDestroyed(PropName propName)
        {
            if (!_propsDestroyed.ContainsKey(propName)) return;
            
            var destroyed = ++_propsDestroyed[propName];
            OnPropDestroyed?.Invoke(propName, destroyed);

            if (AreSuccessConditionsMet())
            {
                FinishRound();
            }
        }

        private bool AreSuccessConditionsMet()
        {
            var chestCondition = _successConditionsData.Boxes.Counter <= _propsDestroyed[PropName.Box];
            var jugsCondition = _successConditionsData.Jugs.Counter <= _propsDestroyed[PropName.Jug];
            var barrelsCondition = _successConditionsData.Barrels.Counter <= _propsDestroyed[PropName.Barrel];
            var bottlesCondition = _successConditionsData.Bottles.Counter <= _propsDestroyed[PropName.Bottle];
            var axesCondition = _successConditionsData.Axes.Counter <= _propsDestroyed[PropName.Axe];

            return chestCondition && jugsCondition && barrelsCondition && bottlesCondition && axesCondition;
        }
    }
}