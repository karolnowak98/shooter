using Zenject;

namespace GlassyCode.Shooter.Core.Time
{
    public class TimeControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITimeController>().To<TimeController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}
