using GlassyCode.Shooter.Game.DustMap.Data;
using UnityEngine;
using Zenject;

namespace GlassyCode.Shooter.Game.DustMap.Logic
{
    public class DustMapInstaller : MonoInstaller
    {
        [SerializeField] private DustMapConfig _config;
        
        public override void InstallBindings()
        {
            Container.Bind<IDustMapConfig>().To<DustMapConfig>().FromInstance(_config).AsSingle();
            
            Container.Bind(typeof(DustMapManager), typeof(IDustMapManager),
                    typeof(ITickable)).To<DustMapManager>().AsSingle();
        }
    }
}