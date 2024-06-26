﻿using System;
using UnityEngine;
using Object = UnityEngine.Object;
using GlassyCode.Shooter.Core.Audio;
using GlassyCode.Shooter.Game.Weapons.Data;

namespace GlassyCode.Shooter.Game.Weapons.Logic
{
    public class Weapon : IWeapon
    {
        private float _reloadStartTime;

        public IWeaponEntity WeaponEntity { get; }
        public int TotalAmmo { get; private set; }
        public int AmmoInMagazine { get; set; }
        public bool IsReloading { get; set; }
        public bool CanReload => AmmoInMagazine < WeaponEntity.NumberOfBulletsInMagazine && !IsReloading 
            && (TotalAmmo > 0 || AmmoInMagazine <= 0);

        public event Action OnReloadStart;
        public event Action<float> OnReloadProgressChanged;

        public Weapon(IWeaponEntity weaponEntity, Transform weaponSlot)
        {
            WeaponEntity = weaponEntity;
            TotalAmmo = WeaponEntity.NumberOfBulletsInMagazine * WeaponEntity.NumberOfMagazines;
            AmmoInMagazine = weaponEntity.NumberOfBulletsInMagazine;

            Object.Instantiate(WeaponEntity.Prefab, weaponSlot);
        }

        public void Tick()
        {
            if (IsReloading)
            {
                var elapsedReloadTime = Time.time - _reloadStartTime;
                var reloadProgress = Mathf.Clamp01(elapsedReloadTime / WeaponEntity.ReloadTime);

                OnReloadProgressChanged?.Invoke(reloadProgress);

                if (elapsedReloadTime >= WeaponEntity.ReloadTime)
                {
                    FinishReload();
                }
            }
        }

        public void StartReload()
        {
            if (!CanReload) return;
            
            IsReloading = true;
            _reloadStartTime = Time.time;

            WeaponEntity.ReloadSound.Play();
            OnReloadStart?.Invoke();
        }

        public void StopReload()
        {
            IsReloading = false;
        }

        private void FinishReload()
        {
            var ammoToAdd = Math.Min(WeaponEntity.NumberOfBulletsInMagazine - AmmoInMagazine, TotalAmmo);

            AmmoInMagazine += ammoToAdd;
            TotalAmmo -= ammoToAdd;
            IsReloading = false;

            OnReloadProgressChanged?.Invoke(1);
        }
    }
}