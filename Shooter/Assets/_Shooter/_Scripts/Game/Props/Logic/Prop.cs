using System;
using UnityEngine;
using GlassyCode.Shooter.Game.Props.Data;
using GlassyCode.Shooter.Game.Props.Enums;

namespace GlassyCode.Shooter.Game.Props.Logic
{
    public class Prop : MonoBehaviour, IDestroyable
    {
        [SerializeField] private PropEntity _data;
        
        private int _currentDurability;

        public PropMaterialType MaterialType => _data.MaterialType;

        public event Action OnDestroy;

        private void Awake()
        {
            _currentDurability = _data.Durability;
        }
        
        public void TakeDamage(int damage)
        {
            _currentDurability -= damage;

            if (_currentDurability <= 0)
            {
                OnDestroy?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}