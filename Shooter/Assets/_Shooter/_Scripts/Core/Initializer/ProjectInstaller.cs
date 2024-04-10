using GlassyCode.Shooter.Game.Input.Logic;
using Zenject;

namespace GlassyCode.Shooter.Core.Initializer
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputManager>().AsSingle().NonLazy();
            Container.Bind<IInitializable>().To<InputManager>().FromResolve();
        }
    }
}