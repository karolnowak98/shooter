using UnityEngine;
using Zenject;
using GlassyCode.Shooter.Game.Player.Data;
using GlassyCode.Shooter.Game.Player.Logic.Cameras;
using GlassyCode.Shooter.Game.Player.Logic.Movement;

namespace GlassyCode.Shooter.Game.Player.Logic
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Transform _player;
        [SerializeField] private Rigidbody _playerRb;
        [SerializeField] private Transform _playerOrientation;
        [SerializeField] private Transform _playerCameraPosition;
        [SerializeField] private Transform _playerCamHolder;
        
        public override void InstallBindings()
        {
            BindInstances();
            BindClasses();
        }
        
        private void BindInstances()
        {
            Container.BindInstance(_playerConfig.CameraData);
            Container.BindInstance(_playerConfig.MovementData);
        }

        private void BindClasses()
        {
            Container.Bind(typeof(CameraController), typeof(ICameraController), typeof(ITickable), typeof(IInitializable))
                .To<CameraController>().AsSingle().WithArguments(_playerCamHolder, _playerCameraPosition, _playerOrientation);
            
            Container.Bind(typeof(MovementController), typeof(IMovementController), typeof(IInitializable), 
                typeof(ITickable), typeof(IFixedTickable)).To<MovementController>().AsSingle().WithArguments(_playerOrientation, _playerRb, _player);
        }
    }
}