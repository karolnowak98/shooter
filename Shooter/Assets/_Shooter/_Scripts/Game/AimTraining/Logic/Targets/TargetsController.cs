using System;
using UnityEngine;
using Object = UnityEngine.Object;
using GlassyCode.Shooter.Core.Utility;
using GlassyCode.Shooter.Game.AimTraining.Data;
using GlassyCode.Shooter.Game.Props.Logic;
using GlassyCode.Shooter.Game.Weapons.Logic;
using GlassyCode.Shooter.Game.Weapons.Logic.Shooting;

namespace GlassyCode.Shooter.Game.AimTraining.Logic.Targets
{
    public class TargetsController : ITargetsController, IDisposable
    {
        private IShootingController _shootingController;
        private readonly BoxCollider _targetsSpawnArea;
        private readonly GameObject _targetPrefab;
        private readonly uint _hitsCondition;
        private readonly float _accuracyCondition;
        
        private GameObject _lastCreatedTarget;
        
        public uint Hits { get; private set; }
        public uint Misses { get; private set; }
        public float Accuracy  => Hits + Misses == 0 ? 0 : (float) Hits / (Hits + Misses) * 100f;
        public bool AreSuccessConditionsMet => IsAccuracyConditionMet && IsHitsConditionMet;
        public bool IsAccuracyConditionMet => Accuracy >= _accuracyCondition;
        public bool IsHitsConditionMet => Hits >= _hitsCondition;

        public event Action<uint> OnHitsIncremented;
        public event Action<uint> OnMissesIncremented;
        
        public TargetsController(IShootingController shootingController, BoxCollider targetsSpawnArea, 
            GameObject targetPrefab, RoundSuccessConditionsData successConditionsData)
        {
            _shootingController = shootingController;
            _targetsSpawnArea = targetsSpawnArea;
            _targetPrefab = targetPrefab;
            _hitsCondition = successConditionsData.HitsConditionData.Counter;
            _accuracyCondition = successConditionsData.AccuracyConditionData.Percentage;
            
            _shootingController.OnShoot += OnHit;
        }
        
        public void Dispose()
        {
            _shootingController.OnShoot -= OnHit;
        }
        
        public void Reset()
        {
            Hits = 0;
            Misses = 0;
            
            if (_lastCreatedTarget is not null)
            {
                Object.Destroy(_lastCreatedTarget);
            }
        }

        public void SpawnTargetAtRandomPosition()
        {
            var spawnPoint = _targetsSpawnArea.GetRandomPointInCollider();
            
            _lastCreatedTarget = Object.Instantiate(_targetPrefab, spawnPoint, _targetPrefab.transform.rotation);
        }

        private void OnHit(IDestroyable hitObj)
        {
            if (hitObj != null)
            {
                Hits++;
                OnHitsIncremented?.Invoke(Hits);
                SpawnTargetAtRandomPosition();
            }
            else
            {
                Misses++;
                OnMissesIncremented?.Invoke(Misses);
            }
        }
    }
}