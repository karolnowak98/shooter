using GlassyCode.Shooter.Game.AimTraining.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Game.AimTraining.Logic
{
    public class AimTrainingInstaller : MonoInstaller
    {
        [SerializeField] private AimTrainingConfig _config;
        
        public override void InstallBindings()
        {
            Container.Bind<IAimTrainingConfig>().To<AimTrainingConfig>().FromInstance(_config).AsSingle();
            
            Container.Bind(typeof(AimTrainingController), typeof(IAimTrainingController), 
                    typeof(ITickable)).To<AimTrainingController>().AsSingle();
        }
    }
}