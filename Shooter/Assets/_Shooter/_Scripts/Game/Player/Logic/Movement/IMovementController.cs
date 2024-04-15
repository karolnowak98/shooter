using UnityEngine;

namespace GlassyCode.Shooter.Game.Player.Logic.Movement
{
    public interface IMovementController
    {
        Transform Player { get; }
        void EnableMovement();
        void DisableMovement();
    }
}