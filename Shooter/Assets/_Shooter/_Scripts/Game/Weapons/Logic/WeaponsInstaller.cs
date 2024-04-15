using UnityEngine;
using Zenject;
using GlassyCode.Shooter.Game.Weapons.Data;
using GlassyCode.Shooter.Game.Weapons.Logic.Shooting;

namespace GlassyCode.Shooter.Game.Weapons.Logic
{
    public class WeaponsInstaller : MonoInstaller
    {
        [SerializeField] private WeaponsConfig _config;
        [SerializeField] private WeaponSlotData[] _weaponSlots;
            
        public override void InstallBindings()
        {
            Container.Bind<IWeaponsConfig>().To<WeaponsConfig>().FromInstance(_config).AsSingle();
            
            Container.Bind(typeof(WeaponManager), typeof(IWeaponManager), 
                typeof(ITickable)).To<WeaponManager>().AsSingle().WithArguments(_weaponSlots).NonLazy();
            
            Container.Bind(typeof(ShootingController), typeof(IShootingController), 
                    typeof(ITickable)).To<ShootingController>().AsSingle();
        }
    }
}