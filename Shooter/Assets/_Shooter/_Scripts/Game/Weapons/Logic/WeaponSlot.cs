using GlassyCode.Shooter.Game.Weapons.Data;
using GlassyCode.Shooter.Game.Weapons.Enums;
using GlassyCode.Shooter.Game.Weapons.Logic.Interfaces;
using UnityEngine;

namespace GlassyCode.Shooter.Game.Weapons.Logic
{
    public class WeaponSlot : IWeaponSlot
    {
        private WeaponSlotData _data;
        
        public IWeapon Weapon { get; private set; }
        public WeaponType Type => _data.Type;
        public Transform Transform => _data.Transform;
        
        
        public WeaponSlot(WeaponSlotData data)
        {
            _data = data;
        }

        public void PickUpWeapon(IWeapon weapon) => Weapon = weapon;

        public void EquipWeapon()
        {
            Transform.gameObject.SetActive(true);
        } 

        public void TakeOffWeapon()
        {
            Weapon.StopReload();
            Transform.gameObject.SetActive(false);
        }
    }
}