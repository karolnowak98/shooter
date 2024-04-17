using System;
using UnityEngine;
using GlassyCode.Shooter.Core.Audio;
using GlassyCode.Shooter.Core.Input;
using GlassyCode.Shooter.Core.Particles;
using GlassyCode.Shooter.Game.Props.Enums;
using GlassyCode.Shooter.Game.Props.Logic;
using GlassyCode.Shooter.Game.Weapons.Logic;

namespace GlassyCode.Shooter.Game.Player.Logic.Shooting
{
    public class ShootingController : IShootingController
    {
        private readonly IInputManager _inputManager;
        private readonly IWeaponManager _weaponManager;
        private readonly Transform _mainCam;
        
        private bool _canShoot;
        private bool _isShooting;
        private float _lastShotTime;
        private float _nextRapidFireTime;

        public event Action<IDestroyable> OnShoot;
        public event Action<PropName> OnPropDestroyed;

        public ShootingController(IInputManager inputManager, IWeaponManager weaponManager)
        {
            _inputManager = inputManager;
            _weaponManager = weaponManager;
            
            if (Camera.main)
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
            AddListeners();
            _weaponManager.EnableWeaponSwapping();
            _canShoot = true;
        }

        public void DisableShooting()
        {
            _canShoot = false;
            _isShooting = false;
            _weaponManager.DisableWeaponSwapping();
            RemoveListeners();
        }
        
        private void AddListeners()
        {
            _inputManager.OnLmbPerformed += StartShooting;
            _inputManager.OnLmbCanceled += StopShooting;
            _inputManager.OnRPressed += StartReload;
        }

        private void RemoveListeners()
        {
            _inputManager.OnLmbPerformed -= StartShooting;
            _inputManager.OnLmbCanceled -= StopShooting;
            _inputManager.OnRPressed -= StartReload;
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
            var data = weaponInHand.WeaponEntity;
            IDestroyable hitObject = null;

            if (weaponInHand.AmmoInMagazine <= 0)
            {
                StartReload();
                return;
            }
            
            if (Time.time - _lastShotTime <= data.ShootCooldown) return;

            var mainCamForward = _mainCam.forward;
            var layerMasks = LayerMask.GetMask("Prop") | LayerMask.GetMask("Ground");
            
            if (Physics.Raycast(_mainCam.position, mainCamForward, out var hit, data.Range, layerMasks))
            {
                hitObject = hit.collider.GetComponent<IDestroyable>();

                if (hitObject != null && data.DestroyMaterials.Contains(hitObject.MaterialType))
                {
                    var isDestroyed = hitObject.TakeDamage(data.Damage);

                    if (isDestroyed)
                    {
                        OnPropDestroyed?.Invoke(hitObject.Name);
                    }
                }

                var rotation = Quaternion.LookRotation(-mainCamForward, Vector3.up);
                data.BulletImpactParticleData.PlayAndDestroy(hit.point, rotation);
            }

            data.ShotSound.Play();
            weaponInHand.AmmoInMagazine--;
            _lastShotTime = Time.time;
            
            OnShoot?.Invoke(hitObject);

            if (weaponInHand.AmmoInMagazine <= 0 && weaponInHand.TotalAmmo > 0)
            {
                StartReload();
            }
        }

        private void StartReload()
        {
            var weaponInHand = _weaponManager.WeaponInHand;
            var data = weaponInHand.WeaponEntity;
            
            if (weaponInHand.AmmoInMagazine < data.NumberOfBulletsInMagazine)
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