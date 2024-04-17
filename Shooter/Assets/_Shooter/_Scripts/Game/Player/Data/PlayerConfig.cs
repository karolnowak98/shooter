using UnityEngine;
using GlassyCode.Shooter.Core.Data;

namespace GlassyCode.Shooter.Game.Player.Data
{
    [CreateAssetMenu(menuName = "Configs/Player Config", fileName = "Player Config")]
    public class PlayerConfig : Config, IPlayerConfig
    {
        [SerializeField]
        private PlayerData _playerData;
        
        [SerializeField]
        private CameraData _cameraData;

        [SerializeField]
        private MovementData _movementData;
        
        public PlayerData PlayerData => _playerData;
        public CameraData CameraData => _cameraData;
        public MovementData MovementData => _movementData;
    }
}