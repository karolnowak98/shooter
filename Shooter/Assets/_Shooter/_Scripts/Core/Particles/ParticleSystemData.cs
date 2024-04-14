using UnityEngine;

namespace GlassyCode.Shooter.Core.Particles
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleSystemData : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        public ParticleSystem ParticleSystem => _particleSystem;
    }
}