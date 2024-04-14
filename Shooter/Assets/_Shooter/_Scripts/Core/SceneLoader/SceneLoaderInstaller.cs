using Zenject;

namespace GlassyCode.Shooter.Core.SceneLoader
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle().NonLazy();
        }
    }
}
