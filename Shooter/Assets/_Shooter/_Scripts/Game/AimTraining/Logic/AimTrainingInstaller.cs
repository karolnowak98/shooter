using GlassyCode.Shooter.Game.AimTraining.Data;
using GlassyCode.Shooter.Game.AimTraining.Logic.Interfaces;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Game.AimTraining.Logic
{
    public class AimTrainingInstaller : MonoInstaller
    {
        [SerializeField] private AimTrainingConfig _config;
        [SerializeField] private BoxCollider _targetsSpawnArea;
        [SerializeField] private GameObject _targetPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<IAimTrainingConfig>().To<AimTrainingConfig>().FromInstance(_config).AsSingle();
            
            Container.Bind(typeof(AimTrainingManager), typeof(IAimTrainingManager), 
                    typeof(ITickable)).To<AimTrainingManager>()
                .AsSingle().WithArguments(_targetsSpawnArea, _targetPrefab);
        }
    }
}