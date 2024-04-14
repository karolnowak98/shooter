using System;
using UnityEngine;
using Object = UnityEngine.Object;
using GlassyCode.Shooter.Core.Utility;
using GlassyCode.Shooter.Game.AimTraining.Logic.Interfaces;
using GlassyCode.Shooter.Game.Props.Logic;
using GlassyCode.Shooter.Game.Weapons.Logic.Interfaces;

namespace GlassyCode.Shooter.Game.AimTraining.Logic
{
    public class TargetsController : ITargetsController
    {
        private readonly BoxCollider _targetsSpawnArea;
        private readonly GameObject _targetPrefab;

        public event Action<uint> OnHitsIncremented;
        public event Action<uint> OnMissesIncremented;

        public uint Hits { get; private set; }
        public uint Misses { get; private set; }
        public float Accuracy  => Hits + Misses == 0 ? 0 : (float) Hits / (Hits + Misses) * 100f;
        
        public TargetsController(IShootingController shootingController, BoxCollider targetsSpawnArea, GameObject targetPrefab)
        {
            shootingController.OnShoot += OnHit;
            _targetsSpawnArea = targetsSpawnArea;
            _targetPrefab = targetPrefab;
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

        public void ResetStats()
        {
            Hits = 0;
            Misses = 0;
        }

        public void SpawnTargetAtRandomPosition()
        {
            var spawnPoint = _targetsSpawnArea.GetRandomPointInCollider();
            
            Object.Instantiate(_targetPrefab, spawnPoint, _targetPrefab.transform.rotation);
        }
    }
}