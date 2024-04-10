using GlassyCode.Shooter.Core.Data;
using UnityEngine;

namespace GlassyCode.Shooter.Game.Player.Data
{
    [CreateAssetMenu(menuName = "Configs/Player Config", fileName = "Player Config")]
    public class PlayerConfig : Config
    {
        [Header("Camera Settings")]
        [SerializeField, Tooltip("Configuration data for the player's camera.")]
        private CameraData _cameraData;

        [Header("Movement Settings")]
        [SerializeField, Tooltip("Configuration data for the player's movement.")]
        private MovementData _movementData;

        public CameraData CameraData => _cameraData;
        public MovementData MovementData => _movementData;
    }
}