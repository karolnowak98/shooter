using Zenject;

namespace GlassyCode.Shooter.Game.Missions.Logic
{
    public class MissionsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(MissionsController), typeof(IMissionsController))
                .To<MissionsController>().AsSingle();
        }
    }
}