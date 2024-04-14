using GlassyCode.Shooter.Game.States.Data;

namespace GlassyCode.Shooter.Game.States.Logic.Interfaces
{
    public interface IGameStatesManager
    {
        GameMode GameMode { get; set; }
        void ChangeStateToMainMenu();
        void ChangeStateToEntry();
        void ChangeStateToAimTraining(GameMode gameMode);
    }
}
