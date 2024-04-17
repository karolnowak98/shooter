using UnityEngine;

namespace GlassyCode.Shooter.Game.Player.Logic.Cameras
{
    public interface ICameraController
    {
        void Tick();
        void LockCamera();
        void UnlockCamera();
        void ResetCamera(Vector3 rotation);
    }
}