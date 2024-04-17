using UnityEngine;
using Zenject;
using GlassyCode.Shooter.Game.AimMap.Data;

namespace GlassyCode.Shooter.Game.AimMap.Logic
{
    public sealed class AimMapInstaller : MonoInstaller
    {
        [SerializeField] private AimMapConfig _config;
        [SerializeField] private BoxCollider _targetsSpawnArea;
        [SerializeField] private GameObject _targetPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<IAimMapConfig>().To<AimMapConfig>().FromInstance(_config).AsSingle();
            
            Container.Bind(typeof(AimMapManager), typeof(IAimMapManager), 
                    typeof(ITickable)).To<AimMapManager>()
                .AsSingle().WithArguments(_targetsSpawnArea, _targetPrefab);
        }
    }
}