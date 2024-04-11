using Zenject;

namespace GlassyCode.Shooter.Core.Input.Logic
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(InputManager), typeof(IInputManager), 
                    typeof(IInitializable)).To<InputManager>().AsSingle().NonLazy();
        }
    }
}