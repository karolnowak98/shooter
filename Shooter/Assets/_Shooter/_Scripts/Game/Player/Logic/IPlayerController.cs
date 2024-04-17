using GlassyCode.Shooter.Game.Player.Logic.Cameras;
using GlassyCode.Shooter.Game.Player.Logic.Movement;
using GlassyCode.Shooter.Game.Player.Logic.Shooting;

namespace GlassyCode.Shooter.Game.Player.Logic
{
    public interface IPlayerController
    {
        IMovementController MovementController { get; }
        ICameraController CameraController { get; }
        IShootingController ShootingController { get; }
        void EnableControls();
        void DisableControls();
        void Reset();
    }
}