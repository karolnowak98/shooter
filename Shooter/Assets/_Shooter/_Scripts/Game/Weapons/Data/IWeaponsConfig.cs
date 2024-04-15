using System.Collections.Generic;
using GlassyCode.Shooter.Game.Weapons.Enums;

namespace GlassyCode.Shooter.Game.Weapons.Data
{
    public interface IWeaponsConfig
    {
        WeaponType StartingSlot { get; }
        IEnumerable<WeaponEntity> StartingWeapons { get; }
    }
}