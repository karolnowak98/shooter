using System;
using GlassyCode.Shooter.Core.Audio.Logic;
using UnityEngine;
using Object = UnityEngine.Object;
using Zenject;
using GlassyCode.Shooter.Core.Input.Logic;
using GlassyCode.Shooter.Core.Particles;
using GlassyCode.Shooter.Game.Player.Logic.Interfaces;
using GlassyCode.Shooter.Game.Props.Logic;
using GlassyCode.Shooter.Game.Weapons.Logic.Interfaces;

namespace GlassyCode.Shooter.Game.Weapons.Logic
{
    public class ShootingController : IShootingController, ITickable
    {
        private IInputManager _inputManager;
        private IWeaponManager _weaponManager;
        private IMovementController _movementController;
        
        private Transform _mainCam;
        private bool _canShoot;
        private bool _isShooting;
        private float _lastShotTime;
        private float _nextRapidFireTime;

        public event Action<IDestroyable> OnShoot;

        [Inject]
        private void Construct(IInputManager inputManager, IWeaponManager weaponManager, IMovementController movementController)
        {
            _inputManager = inputManager;
            _weaponManager = weaponManager;
            _movementController = movementController;

            _inputManager.OnLmbPerformed += StartShooting;
            _inputManager.OnLmbCanceled += StopShooting;
            _inputManager.OnRPressed += StartReload;

            if (Camera.main != null)
            {
                _mainCam = Camera.main.transform;
            }
            else
            {
                Debug.LogError(nameof(Camera.main) + " has not been found on the scene!");
            }
        }

        public void Tick()
        {
            if (!_isShooting) return;
            
            if (_weaponManager.WeaponInHand.WeaponEntity.IsRapidFire)
            {
                HandleRapidFire();
            }
        }


        public void EnableShooting()
        {
            _canShoot = true;
        }

        public void DisableShooting()
        {
            _canShoot = false;
        }

        private void HandleRapidFire()
        {
            if (Time.time > _nextRapidFireTime)
            {
                Shoot();
                _nextRapidFireTime = Time.time + _weaponManager.WeaponInHand.WeaponEntity.ShootCooldown;
            }
        }

        private void Shoot()
        {
            var weaponInHand = _weaponManager.WeaponInHand;
            var ammoInMagazine = weaponInHand.AmmoInMagazine;
            var data = weaponInHand.WeaponEntity;
            IDestroyable hitObject = null;

            if (ammoInMagazine <= 0 || Time.time - _lastShotTime <= data.ShootCooldown) return;

            var mainCamForward = _mainCam.forward;

            if (Physics.Raycast(_mainCam.position, mainCamForward, out var hit, data.Range, LayerMask.GetMask("Prop")))
            {
                hitObject = hit.collider.GetComponent<IDestroyable>();

                if (hitObject != null && data.DestroyMaterials.Contains(hitObject.MaterialType))
                {
                    hitObject.TakeDamage(data.Damage);
                }

                var rotation = Quaternion.LookRotation(-mainCamForward, Vector3.up);
                data.BulletImpactParticleData.PlayAndDestroy(hit.point, rotation);
            }

            data.ShotSound.Play(_movementController.Player);
            ammoInMagazine--;
            _lastShotTime = Time.time;
            
            OnShoot?.Invoke(hitObject);

            if (ammoInMagazine <= 0 && weaponInHand.TotalAmmo > 0)
            {
                StartReload();
            }
        }

        private void StartReload()
        {
            var weaponInHand = _weaponManager.WeaponInHand;

            if (weaponInHand.AmmoInMagazine < weaponInHand.WeaponEntity.NumberOfBulletsInMagazine)
            {
                weaponInHand.StartReload();
            }

            StopShooting();
        }
        
        private void StartShooting()
        {
            if (!_canShoot) return;
            if (_weaponManager.WeaponInHand.IsReloading) return;

            _isShooting = true;
            Shoot();
            _nextRapidFireTime = Time.time + _weaponManager.WeaponInHand.WeaponEntity.ShootCooldown;
        }
        
        private void StopShooting()
        {
            _isShooting = false;
        }
    }
}