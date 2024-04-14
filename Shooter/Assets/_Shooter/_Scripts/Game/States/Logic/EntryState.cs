using GlassyCode.Shooter.Core.SceneLoader;
using GlassyCode.Shooter.Core.Time;
using GlassyCode.Shooter.Game.States.Logic.Interfaces;
using Zenject;

namespace GlassyCode.Shooter.Game.States.Logic
{
    public class EntryState : IGameState
    {
        private ISceneLoader _sceneLoader;
        
        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter(GameStatesManager owner, params object[] optionalParams)
        {
            _sceneLoader.LoadMenuScene();
            TimeController.Pause();
        }
        
        public void Exit(GameStatesManager owner, params object[] optionalParams)
        {
            
        }
        
        public void Tick()
        {
            
        }
    }
}
