using UnityEngine;
using Zenject;
using GlassyCode.Shooter.Game.Player.Data;

namespace GlassyCode.Shooter.Game.Player.Logic
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Transform _player;
        [SerializeField] private Rigidbody _playerRb;
        [SerializeField] private Transform _playerOrientation;
        [SerializeField] private Transform _playerCameraPos;
        [SerializeField] private Transform _playerCamHolder;
        
        public override void InstallBindings()
        {
            BindInstances();
            BindClasses();
            BindInterfaces();
        }
        
        private void BindInstances()
        {
            Container.BindInstance(_playerConfig.CameraData);
            Container.BindInstance(_playerConfig.MovementData);
        }

        private void BindInterfaces()
        {
            Container.Bind<IInitializable>().To<MovementController>().FromResolve();
            Container.Bind<ITickable>().To<MovementController>().FromResolve();
            Container.Bind<IFixedTickable>().To<MovementController>().FromResolve();
        }

        private void BindClasses()
        {
            Container.Bind(typeof(CameraController), typeof(ICameraController), typeof(ITickable))
                .To<CameraController>().AsSingle().WithArguments(_playerCamHolder, _playerCameraPos, _playerOrientation);
            
            Container.Bind<MovementController>().AsSingle().WithArguments(_playerOrientation, _playerRb, _player);
        }
    }
}