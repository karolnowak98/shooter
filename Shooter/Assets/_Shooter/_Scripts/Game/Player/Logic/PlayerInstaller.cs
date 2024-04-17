using System;
using UnityEngine;
using Zenject;
using GlassyCode.Shooter.Game.Player.Data;

namespace GlassyCode.Shooter.Game.Player.Logic
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Transform _player;
        [SerializeField] private Rigidbody _playerRb;
        [SerializeField] private Transform _playerOrientation;
        [SerializeField] private Transform _playerCameraPosition;
        [SerializeField] private Transform _playerCamHolder;
        
        public override void InstallBindings()
        {
            Container.Bind<IPlayerConfig>().To<PlayerConfig>().FromInstance(_playerConfig).AsSingle();

            Container.Bind(typeof(PlayerController), typeof(IPlayerController), typeof(IDisposable),
                    typeof(ITickable), typeof(IFixedTickable)).To<PlayerController>().AsSingle()
                .WithArguments(_player, _playerRb, _playerOrientation, _playerCameraPosition, _playerCamHolder);
        }
    }
}