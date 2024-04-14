using UnityEngine;

namespace GlassyCode.Shooter.Game.Player.Logic.Interfaces
{
    public interface IMovementController
    {
        Transform Player { get; }
        void EnableMovement();
        void DisableMovement();
    }
}