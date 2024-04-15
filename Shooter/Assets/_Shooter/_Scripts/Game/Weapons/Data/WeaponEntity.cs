using UnityEngine;
using System.Collections.Generic;
using GlassyCode.Shooter.Core.Audio;
using GlassyCode.Shooter.Core.Data;
using GlassyCode.Shooter.Core.Particles;
using GlassyCode.Shooter.Game.Props.Enums;
using GlassyCode.Shooter.Game.Weapons.Enums;

namespace GlassyCode.Shooter.Game.Weapons.Data
{
    [CreateAssetMenu(menuName = "Entities/Weapon Entity", fileName = "Weapon Entity")]
    public class WeaponEntity : Entity, IWeaponEntity
    {
        [Header("General Settings")]
        [Tooltip("The type of the weapon.")]
        [SerializeField]
        private WeaponType _type;

        [Tooltip("The prefab representing the weapon.")]
        [SerializeField]
        private GameObject _prefab;

        [Header("Audio")]
        [SerializeField]
        private AudioSourceData _shotSound;

        [SerializeField]
        private AudioSourceData _reloadSound;

        [Header("Visuals")]
        [Tooltip("The particle system data for bullet impact.")]
        [SerializeField]
        private ParticleSystemData _bulletImpactParticleData;

        [Tooltip("The icon of the weapon.")]
        [SerializeField]
        private Sprite _icon;

        [Tooltip("The icon representing the ammo for this weapon.")]
        [SerializeField]
        private Sprite _ammoIcon;

        [Header("Combat")]
        [Tooltip("The base damage dealt by the weapon.")]
        [SerializeField]
        private int _damage;

        [Tooltip("List of materials that the weapon can destroy.")]
        [SerializeField]
        private List<PropMaterialType> _destroyMaterials;

        [Header("Shooting")]
        [Tooltip("Cooldown between shots.")]
        [SerializeField]
        private float _shootCooldown;

        [Tooltip("Maximum range of the weapon.")]
        [SerializeField]
        private float _range;

        [Tooltip("Is the weapon capable of rapid fire?")]
        [SerializeField]
        private bool _isRapidFire;

        [Tooltip("Number of magazines the weapon starts with.")]
        [SerializeField]
        private int _numberOfMagazines;

        [Tooltip("Number of bullets in a magazine.")]
        [SerializeField]
        private int _numberOfBulletsInMagazine;

        [Tooltip("CountdownTime it takes to reload the weapon.")]
        [SerializeField]
        private float _reloadTime;

        public WeaponType Type => _type;
        public GameObject Prefab => _prefab;
        public AudioSourceData ShotSound => _shotSound;
        public AudioSourceData ReloadSound => _reloadSound;
        public Sprite Icon => _icon;
        public Sprite AmmoIcon => _ammoIcon;
        public ParticleSystemData BulletImpactParticleData => _bulletImpactParticleData;
        public int NumberOfMagazines => _numberOfMagazines;
        public int NumberOfBulletsInMagazine => _numberOfBulletsInMagazine;
        public int Damage => _damage;
        public List<PropMaterialType> DestroyMaterials => _destroyMaterials;
        public float ReloadTime => _reloadTime;
        public float ShootCooldown => _shootCooldown;
        public float Range => _range;
        public bool IsRapidFire => _isRapidFire;
    }
}
