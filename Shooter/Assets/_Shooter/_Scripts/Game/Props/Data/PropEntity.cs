using UnityEngine;
using GlassyCode.Shooter.Core.Data;
using GlassyCode.Shooter.Game.Props.Enums;

namespace GlassyCode.Shooter.Game.Props.Data
{
    [CreateAssetMenu(menuName = "Entities/Prop Entity", fileName = "Prop Entity")]
    public class PropEntity : Entity
    {
        [SerializeField]
        private PropName _name;
        
        [SerializeField]
        private PropMaterialType _materialType;
        
        [Tooltip("How much damage can it take.")]
        [SerializeField] private int _durability;

        public PropName Name => _name;
        public PropMaterialType MaterialType => _materialType;
        public int Durability => _durability;
    }
}