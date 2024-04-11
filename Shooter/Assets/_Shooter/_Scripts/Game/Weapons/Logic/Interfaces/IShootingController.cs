using System;
using GlassyCode.Shooter.Game.Props.Logic;

namespace GlassyCode.Shooter.Game.Weapons.Logic.Interfaces
{
    public interface IShootingController
    {
        event Action<IDestroyable> OnShoot;
    }
}