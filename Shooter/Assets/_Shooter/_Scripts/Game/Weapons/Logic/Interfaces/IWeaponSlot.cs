using GlassyCode.Shooter.Game.Weapons.Enums;
using UnityEngine;

namespace GlassyCode.Shooter.Game.Weapons.Logic.Interfaces
{
    public interface IWeaponSlot
    {
        public IWeapon Weapon { get; }
        public WeaponType Type { get; }
        public Transform Transform { get; }
        public void PickUpWeapon(IWeapon weapon);
        public void EquipWeapon();
        public void TakeOffWeapon();
    }
}