using UnityEngine;

namespace GlassyCode.Shooter.Core.Particles
{
    public static class ParticleSystemExtensions
    {
        public static void PlayAndDestroy(this ParticleSystemData particleSystemData, Transform parentTransform)
        {
            var particleData = Object.Instantiate(particleSystemData, parentTransform.position, particleSystemData.ParticleSystem.transform.rotation);
            
            particleData.PlayAndDestroy();
        }
        
        public static void PlayAndDestroy(this ParticleSystemData particleSystemData, Vector3 position, Quaternion rotation)
        {
            var particleData = Object.Instantiate(particleSystemData, position, rotation);
            
            particleData.PlayAndDestroy();
        }
        
        public static void PlayAndDestroy(this ParticleSystemData particleSystemData)
        {
            var particle = particleSystemData.ParticleSystem;
            particle.Play();
            Object.Destroy(particleSystemData.gameObject, particle.main.duration);
        }
    }
}