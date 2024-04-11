using UnityEngine;
using GlassyCode.Shooter.Core.Data;

namespace GlassyCode.Shooter.Game.Player.Data
{
    [CreateAssetMenu(menuName = "Configs/Player Config", fileName = "Player Config")]
    public class PlayerConfig : Config
    {
        [SerializeField, Tooltip("Configuration data for the player's camera.")]
        private CameraData _cameraData;

        [SerializeField, Tooltip("Configuration data for the player's movement.")]
        private MovementData _movementData;

        public CameraData CameraData => _cameraData;
        public MovementData MovementData => _movementData;
    }
}