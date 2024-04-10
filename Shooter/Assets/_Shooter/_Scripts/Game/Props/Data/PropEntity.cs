using GlassyCode.Shooter.Core.Data;
using GlassyCode.Shooter.Game.Props.Enums;
using UnityEngine;

namespace GlassyCode.Shooter.Game.Props.Data
{
    [CreateAssetMenu(menuName = "Entities/Prop Entity", fileName = "Prop Entity")]
    public class PropEntity : Entity
    {
        [SerializeField] private PropMaterialType _materialType;
        [SerializeField] private int _durability;

        public PropMaterialType MaterialType => _materialType;
        public int Durability => _durability;
    }
}