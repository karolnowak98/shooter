using System;

namespace GlassyCode.Shooter.Game.Weapons.Logic
{
    public interface IWeaponManager
    {
        IWeapon WeaponInHand { get; }
        event Action OnWeaponChanged;
    }
}