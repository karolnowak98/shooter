using GlassyCode.Shooter.Core.States;
using GlassyCode.Shooter.Game.States.Data;
using GlassyCode.Shooter.Game.States.Logic.Interfaces;
using Zenject;

namespace GlassyCode.Shooter.Game.States.Logic
{
    public class GameStatesManager : StateMachine<GameStatesManager>, IInitializable, IGameStatesManager
    {
        [Inject(Id = GameStateInjectIds.EntryStateId)] private IGameState _entryState;
        [Inject(Id = GameStateInjectIds.MainMenuStateId)] private IGameState _mainMenuState;
        [Inject(Id = GameStateInjectIds.GameMenuStateId)] private IGameState _gameMenuState;
        [Inject(Id = GameStateInjectIds.AimTrainingStateId)] private IGameState _aimTrainingState;
        [Inject(Id = GameStateInjectIds.DustStateId)] private IGameState _dustState;
        
        public GameMode GameMode { get; set; }
        
        public void Initialize()
        {
            ChangeStateToEntry(); //Instead of that we can create some config to specify some init config.
        }

        public void ChangeStateToMainMenu()
        {
            ChangeState(_mainMenuState, this);
        }
        
        public void ChangeStateToGameMenu()
        {
            ChangeState(_gameMenuState, this);
        }
        
        public void ChangeStateToEntry()
        {
            ChangeState(_entryState, this);
        }
        
        public void ChangeStateToAimTraining(GameMode gameMode)
        {
            ChangeState(_aimTrainingState, this, gameMode);
        }
        
        public void ChangeStateToDust()
        {
            ChangeState(_dustState, this);
        }
    }
}
