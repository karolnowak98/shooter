using System;
using GlassyCode.Shooter.Core.Input.Logic;
using GlassyCode.Shooter.Game.Props.Logic;
using GlassyCode.Shooter.Game.Weapons.Logic.Interfaces;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace GlassyCode.Shooter.Game.Weapons.Logic
{
    public class ShootingController : IShootingController, ITickable
    {
        private IInputManager _inputManager;
        private IWeaponManager _weaponManager;
        private Transform _mainCam;
        private bool _isShooting;
        private float _lastShotTime;
        private float _nextRapidFireTime;

        public event Action<IDestroyable> OnShoot;

        [Inject]
        private void Construct(IInputManager inputManager, IWeaponManager weaponManager)
        {
            _inputManager = inputManager;
            _weaponManager = weaponManager;

            _inputManager.OnLmbPerformed += StartShooting;
            _inputManager.OnLmbCanceled += StopShooting;
            _inputManager.OnRPressed += StartReload;

            if (Camera.main != null)
            {
                _mainCam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning("Main cam has not been found on the scene!!");
            }
        }

        public void Tick()
        {
            if (_isShooting && _weaponManager.WeaponInHand.WeaponEntity.IsRapidFire)
            {
                HandleRapidFire();
            }
        }

        private void HandleRapidFire()
        {
            if (Time.time > _nextRapidFireTime)
            {
                Shoot();
                _nextRapidFireTime = Time.time + _weaponManager.WeaponInHand.WeaponEntity.ShootCooldown;
            }
        }

        private void StartShooting()
        {
            if (_weaponManager.WeaponInHand.IsReloading) return;

            _isShooting = true;
            Shoot();
            _nextRapidFireTime = Time.time + _weaponManager.WeaponInHand.WeaponEntity.ShootCooldown;
        }

        private void Shoot()
        {
            var weaponInHand = _weaponManager.WeaponInHand;
            var data = weaponInHand.WeaponEntity;
            IDestroyable hitObject = null;

            if (weaponInHand.AmmoInMagazine <= 0 || Time.time - _lastShotTime <= data.ShootCooldown) return;

            if (Physics.Raycast(_mainCam.position, _mainCam.forward, out var hit, data.Range))
            {
                hitObject = hit.collider.GetComponent<IDestroyable>();

                if (hitObject != null && data.DestroyMaterials.Contains(hitObject.MaterialType))
                {
                    hitObject.TakeDamage(data.Damage);
                }
                
                var bulletImpactParticle = data.BulletImpactParticle;

                if (bulletImpactParticle != null)
                {
                    var rotation = Quaternion.LookRotation(-_mainCam.forward, Vector3.up);
                    var obj = Object.Instantiate(bulletImpactParticle, hit.point, rotation);
                    obj.Play();
                    Object.Destroy(obj.gameObject, bulletImpactParticle.main.duration);
                }
            }

            weaponInHand.AmmoInMagazine--;
            _lastShotTime = Time.time;
            
            OnShoot?.Invoke(hitObject);

            if (weaponInHand.AmmoInMagazine == 0 && weaponInHand.TotalAmmo > 0)
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

        private void StopShooting() => _isShooting = false;
    }
}