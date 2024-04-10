using System;
using GlassyCode.Shooter.Game.Weapons.Data;

namespace GlassyCode.Shooter.Game.Weapons.Logic.Interfaces
{
    public interface IWeapon
    {
        public WeaponEntity WeaponEntity { get; }
        public int TotalAmmo { get; }
        public int AmmoInMagazine { get; set; }
        public bool IsReloading { get; set; }
        public event Action OnReloadStart;
        public event Action<float> OnReloadProgressChanged;
        public void StartReload();
        public void StopReload();
        public void Tick();
    }
}