using System;
using System.Collections.Generic;
using Zenject;
using GlassyCode.Shooter.Core.Input;
using GlassyCode.Shooter.Game.Weapons.Data;
using GlassyCode.Shooter.Game.Weapons.Enums;

namespace GlassyCode.Shooter.Game.Weapons.Logic
{
    public sealed class WeaponManager : IWeaponManager, ITickable, IDisposable
    {
        private readonly Dictionary<WeaponType, IWeaponSlot> _slotsByType = new();
        
        private IInputManager _inputManager;
        private IWeaponSlot _selectedSlot;
        
        private Action _changeWeaponAction1;
        private Action _changeWeaponAction2;
        private Action _changeWeaponAction3;
        
        public IWeapon WeaponInHand => _selectedSlot.Weapon;
        
        public event Action OnWeaponChanged;

        [Inject]
        private void Construct(IInputManager inputManager, IWeaponsConfig data, WeaponSlotData[] slotsData)
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

            _changeWeaponAction1 = () => ChangeWeapon(1);
            _changeWeaponAction2 = () => ChangeWeapon(2);
            _changeWeaponAction3 = () => ChangeWeapon(3);
        }
        
        public void Dispose()
        {
            DisableWeaponSwapping();
        }
        
        public void Tick()
        {
            WeaponInHand.Tick();
        }

        public void EnableWeaponSwapping()
        {
            AddListeners();
        }

        public void DisableWeaponSwapping()
        {
            RemoveListeners();
        }
        
        private void AddListeners()
        {
            _inputManager.OnBtn1Pressed += _changeWeaponAction1;
            _inputManager.OnBtn2Pressed += _changeWeaponAction2;
            _inputManager.OnBtn3Pressed += _changeWeaponAction3;
            _inputManager.OnScrollUp += PickNextWeapon;
            _inputManager.OnScrollDown += PickPreviousWeapon;
        }

        private void RemoveListeners()
        {
            _inputManager.OnBtn1Pressed -= _changeWeaponAction1;
            _inputManager.OnBtn2Pressed -= _changeWeaponAction2;
            _inputManager.OnBtn3Pressed -= _changeWeaponAction3;
            _inputManager.OnScrollUp -= PickNextWeapon;
            _inputManager.OnScrollDown -= PickPreviousWeapon;
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

        private IWeaponSlot GetSlotByIndex(int weaponIndex)
        {
            return _slotsByType.GetValueOrDefault((WeaponType) weaponIndex);
        }
    }
}