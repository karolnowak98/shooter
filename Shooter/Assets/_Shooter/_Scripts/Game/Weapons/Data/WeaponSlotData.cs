using System;
using UnityEngine;
using GlassyCode.Shooter.Game.Weapons.Enums;

namespace GlassyCode.Shooter.Game.Weapons.Data
{
    [Serializable]
    public struct WeaponSlotData
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private WeaponType _type;

        public Transform Transform => _transform;
        public WeaponType Type => _type;
    }
}