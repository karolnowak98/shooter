using System;
using GlassyCode.Shooter.Game.Props.Enums;
using GlassyCode.Shooter.Game.Props.Logic;

namespace GlassyCode.Shooter.Game.Player.Logic.Shooting
{
    public interface IShootingController
    {
        event Action<PropName> OnPropDestroyed;
        event Action<IDestroyable> OnShoot;
        void Tick();
        void EnableShooting();
        void DisableShooting();
    }
}