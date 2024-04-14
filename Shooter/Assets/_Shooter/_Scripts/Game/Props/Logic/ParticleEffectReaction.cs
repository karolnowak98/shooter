using GlassyCode.Shooter.Core.Particles;
using UnityEngine;

namespace GlassyCode.Shooter.Game.Props.Logic
{
    public class ParticleEffectReaction : DestroyReaction
    {
        [SerializeField] private ParticleSystemData _particle;
        
        protected override void HandleDestroyReaction()
        {
            _particle.PlayAndDestroy(transform);
        }
    }
}