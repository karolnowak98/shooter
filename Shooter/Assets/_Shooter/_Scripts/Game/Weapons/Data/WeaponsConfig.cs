using UnityEngine;
using System.Collections.Generic;
using GlassyCode.Shooter.Core.Data;
using GlassyCode.Shooter.Game.Weapons.Enums;

namespace GlassyCode.Shooter.Game.Weapons.Data
{
    [CreateAssetMenu(menuName = "Configs/Weapons Config", fileName = "Weapons Config")]
    public class WeaponsConfig : Config, IWeaponsConfig
    {
        [SerializeField] private WeaponType _startingSlot;
        [SerializeField] private WeaponEntity[] _startingWeapons; //Using Odin I would make Dictionary<WeaponType, WeaponEntity> instead
        
        public WeaponType StartingSlot => _startingSlot;
        public IEnumerable<WeaponEntity> StartingWeapons => _startingWeapons;
    }
}