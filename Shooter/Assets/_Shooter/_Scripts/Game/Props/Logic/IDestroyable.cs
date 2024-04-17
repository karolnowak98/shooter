using System;
using GlassyCode.Shooter.Game.Props.Enums;

namespace GlassyCode.Shooter.Game.Props.Logic
{
    public interface IDestroyable
    {
        public PropName Name { get; }
        public PropMaterialType MaterialType { get; }
        public event Action OnDestroy;
        public bool TakeDamage(int damage); //true -> Destroyed
    }
}