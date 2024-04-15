using System;
using GlassyCode.Shooter.Game.Props.Logic;

namespace GlassyCode.Shooter.Game.Weapons.Logic.Shooting
{
    public interface IShootingController
    {
        event Action<IDestroyable> OnShoot;
        void EnableShooting();
        void DisableShooting();
    }
}