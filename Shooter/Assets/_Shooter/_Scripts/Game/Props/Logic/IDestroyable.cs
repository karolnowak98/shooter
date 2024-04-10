using System;
using GlassyCode.Shooter.Game.Props.Enums;

namespace GlassyCode.Shooter.Game.Props.Logic
{
    public interface IDestroyable
    {
        public PropMaterialType MaterialType { get; }
        public event Action OnDestroy;
        public void TakeDamage(int damage);
    }
}