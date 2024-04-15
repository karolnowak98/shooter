using UnityEngine;
using GlassyCode.Shooter.Core.Data;

namespace GlassyCode.Shooter.Game.Player.Data
{
    [CreateAssetMenu(menuName = "Configs/Player Config", fileName = "Player Config")]
    public class PlayerConfig : Config, IPlayerConfig
    {
        [Tooltip("Configuration data for the player's camera.")]
        [SerializeField]
        private CameraData _cameraData;

        [Tooltip("Configuration data for the player's movement.")]
        [SerializeField]
        private MovementData _movementData;

        public CameraData CameraData => _cameraData;
        public MovementData MovementData => _movementData;
    }
}