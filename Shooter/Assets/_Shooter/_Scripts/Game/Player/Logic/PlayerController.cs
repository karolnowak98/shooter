using System;
using UnityEngine;
using Zenject;
using GlassyCode.Shooter.Core.Cursors;
using GlassyCode.Shooter.Core.Input;
using GlassyCode.Shooter.Game.Player.Data;
using GlassyCode.Shooter.Game.Player.Logic.Cameras;
using GlassyCode.Shooter.Game.Player.Logic.Movement;
using GlassyCode.Shooter.Game.Player.Logic.Shooting;
using GlassyCode.Shooter.Game.Weapons.Logic;

namespace GlassyCode.Shooter.Game.Player.Logic
{
    public sealed class PlayerController : IPlayerController, ITickable, IFixedTickable, IDisposable
    {
        public Transform Player { get; private set; }
        public PlayerData Data { get; private set; }
        public IMovementController MovementController { get; private set; }
        public ICameraController CameraController { get; private set; }
        public IShootingController ShootingController { get; private set; }

        [Inject]
        private void Construct(IInputManager inputManager, ICursorController cursorController, IWeaponManager weaponManager,
            IPlayerConfig config, Transform player, Rigidbody rb, Transform orientation, Transform playerCameraPosition, Transform cameraHolder)
        {
            Player = player;
            Data = config.PlayerData;
            
            MovementController = new MovementController(inputManager, player, rb, orientation, config.MovementData);
            CameraController = new CameraController(cursorController, orientation, playerCameraPosition, cameraHolder, config.CameraData);
            ShootingController = new ShootingController(inputManager, weaponManager);
        }
        
        public void Dispose()
        {
            MovementController.Dispose();
        }
        
        public void Tick()
        {
            CameraController.Tick();
            ShootingController.Tick();
            MovementController.Tick();
        }

        public void FixedTick()
        {
            MovementController.FixedTick();
        }

        public void EnableControls()
        {
            CameraController.UnlockCamera();
            ShootingController.EnableShooting();
            MovementController.EnableMovement();
        }
        
        public void DisableControls()
        {
            MovementController.DisableMovement();
            ShootingController.DisableShooting();
            CameraController.LockCamera();
        }

        public void Reset()
        {
            Player.position = Data.StartingPosition;
            Player.rotation = Quaternion.Euler(Data.StartingRotation);
            CameraController.ResetCamera( Data.StartingRotation);
        }
    }
}