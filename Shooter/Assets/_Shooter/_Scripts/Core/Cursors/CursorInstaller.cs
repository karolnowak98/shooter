using Zenject;

namespace GlassyCode.Shooter.Core.Cursors
{
    public sealed class CursorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(CursorController), typeof(ICursorController)).To<CursorController>()
                .AsSingle().NonLazy();
        }
    }
}