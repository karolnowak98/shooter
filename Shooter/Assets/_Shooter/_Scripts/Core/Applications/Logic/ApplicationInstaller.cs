using GlassyCode.Shooter.Core.Applications.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Core.Applications.Logic
{
    public class ApplicationInstaller : MonoInstaller
    {
        [SerializeField] private ApplicationConfig _applicationConfig;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_applicationConfig);
            
            Container.Bind(typeof(ApplicationController), typeof(IApplicationController), typeof(IInitializable))
                .To<ApplicationController>().AsSingle().NonLazy();
        }
    }
}