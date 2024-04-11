using System;
using System.Collections.Generic;
using GlassyCode.Shooter.Core.Input.Logic;
using GlassyCode.Shooter.Game.Weapons.Data;
using GlassyCode.Shooter.Game.Weapons.Enums;
using GlassyCode.Shooter.Game.Weapons.Logic.Interfaces;
using Zenject;

namespace GlassyCode.Shooter.Game.Weapons.Logic
{
    public class WeaponManager : IWeaponManager, ITickable
    {
        private readonly Dictionary<WeaponType, IWeaponSlot> _slotsByType = new();
        private IInputManager _inputManager;
        private IWeaponSlot _selectedSlot;
        
        public IWeapon WeaponInHand => _selectedSlot.Weapon;
        
        public event Action OnWeaponChanged;

        [Inject]
        private void Construct(IInputManager inputManager, WeaponsConfig data, WeaponSlotData[] slotsData)
        {
            _inputManager = inputManager;

            foreach (var slotData in slotsData)
            {
                var slot = new WeaponSlot(slotData);
                _slotsByType[slot.Type] = slot;
            }
            
            foreach (var entity in data.StartingWeapons)
            {
                if (!_slotsByType.TryGetValue(entity.Type, out var slot)) continue;
                
                var weapon = new Weapon(entity, slot.Transform);
                slot.PickUpWeapon(weapon);
            }

            _selectedSlot = _slotsByType[data.StartingSlot];
            _selectedSlot?.EquipWeapon();
            
            _inputManager.OnBtn1Pressed += () => ChangeWeapon(1);
            _inputManager.OnBtn2Pressed += () => ChangeWeapon(2);
            _inputManager.OnBtn3Pressed += () => ChangeWeapon(3);
            _inputManager.OnScrollUp += PickNextWeapon;
            _inputManager.OnScrollDown += PickPreviousWeapon;
        }
        
        public void Tick()
        {
            WeaponInHand.Tick();
        }
        
        private void PickNextWeapon()
        {
            var nextIndex = (int)_selectedSlot.Type % Enum.GetValues(typeof(WeaponType)).Length + 1;
            ChangeWeapon(nextIndex);
        }

        private void PickPreviousWeapon()
        {
            var previousIndex = (int)_selectedSlot.Type - 1 == 0 ? Enum.GetValues(typeof(WeaponType)).Length : (int)_selectedSlot.Type - 1;
            ChangeWeapon(previousIndex);
        }

        private void ChangeWeapon(int weaponIndex)
        {
            var newSlot = GetSlotByIndex(weaponIndex);

            if (newSlot == null || newSlot == _selectedSlot) return;

            _selectedSlot.TakeOffWeapon();
            _selectedSlot = newSlot;
            _selectedSlot.EquipWeapon();

            OnWeaponChanged?.Invoke();
        }

        private IWeaponSlot GetSlotByIndex(int weaponIndex) => _slotsByType.TryGetValue((WeaponType)weaponIndex, out var slot) ? slot : null;
    }
}