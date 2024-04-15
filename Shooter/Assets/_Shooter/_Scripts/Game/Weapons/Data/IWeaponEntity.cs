using System.Collections.Generic;
using UnityEngine;
using GlassyCode.Shooter.Core.Audio;
using GlassyCode.Shooter.Core.Particles;
using GlassyCode.Shooter.Game.Props.Enums;
using GlassyCode.Shooter.Game.Weapons.Enums;

namespace GlassyCode.Shooter.Game.Weapons.Data
{
    public interface IWeaponEntity
    {
        WeaponType Type { get; }
        GameObject Prefab { get; }
        AudioSourceData ShotSound { get; }
        AudioSourceData ReloadSound { get; }
        Sprite Icon { get; }
        Sprite AmmoIcon { get; }
        ParticleSystemData BulletImpactParticleData { get; }
        int NumberOfMagazines { get; }
        int NumberOfBulletsInMagazine { get; }
        int Damage { get; }
        List<PropMaterialType> DestroyMaterials { get; }
        float ReloadTime { get; }
        float ShootCooldown { get; }
        float Range { get; }
        bool IsRapidFire { get; }
    }
}