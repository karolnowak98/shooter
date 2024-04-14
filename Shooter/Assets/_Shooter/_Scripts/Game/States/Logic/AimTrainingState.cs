using GlassyCode.Shooter.Core.SceneLoader;
using GlassyCode.Shooter.Game.States.Data;
using GlassyCode.Shooter.Game.States.Logic.Interfaces;
using Zenject;

namespace GlassyCode.Shooter.Game.States.Logic
{
    public class AimTrainingState : IGameState
    {
        private ISceneLoader _sceneLoader;
        
        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter(GameStatesManager owner, params object[] optionalParams)
        {
            owner.GameMode = (GameMode) optionalParams[0];
            _sceneLoader.LoadGameScene();
        }
        
        public void Exit(GameStatesManager owner, params object[] optionalParams)
        {
            
        }

        public void Tick()
        {
            
        }
    }
}
