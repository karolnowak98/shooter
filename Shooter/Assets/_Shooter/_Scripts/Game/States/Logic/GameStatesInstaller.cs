using GlassyCode.Shooter.Game.States.Data;
using GlassyCode.Shooter.Game.States.Logic.Interfaces;
using Zenject;

namespace GlassyCode.Shooter.Game.States.Logic
{
    public class GameStatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(GameStatesManager), typeof(IGameStatesManager)
                    , typeof(ITickable), typeof(IInitializable))
                .To<GameStatesManager>()
                .FromSubContainerResolve()
                .ByMethod(InstallGameStateMachine)
                .AsSingle()
                .NonLazy();
        }

        private static void InstallGameStateMachine(DiContainer subContainer)
        {
            subContainer.Bind(typeof(GameStatesManager), typeof(IGameStatesManager)
                    , typeof(ITickable), typeof(IInitializable))
                .To<GameStatesManager>()
                .AsSingle()
                .NonLazy();

            subContainer.Bind<IGameState>().WithId(GameStateInjectIds.EntryStateId).To<EntryState>().AsSingle();
            subContainer.Bind<IGameState>().WithId(GameStateInjectIds.MainMenuStateId).To<MainMenuState>().AsSingle();
            subContainer.Bind<IGameState>().WithId(GameStateInjectIds.GameMenuStateId).To<GameMenuState>().AsSingle();
            subContainer.Bind<IGameState>().WithId(GameStateInjectIds.AimTrainingStateId).To<AimTrainingState>().AsSingle();
            subContainer.Bind<IGameState>().WithId(GameStateInjectIds.DustStateId).To<DustState>().AsSingle();
        }
    }
}