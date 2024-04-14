using GlassyCode.Shooter.Core.Audio.Data;
using UnityEngine;

namespace GlassyCode.Shooter.Core.Audio.Logic
{
    public static class AudioSourceExtensions
    {
        public static void Play(this AudioSourceData audioSourceData, Transform parentPlace)
        {
            var data = Object.Instantiate(audioSourceData, parentPlace.position, parentPlace.rotation);
            var audioSource = data.AudioSource;
            
            audioSource.volume = Random.Range(data.VolumeRanges.x, data.VolumeRanges.y);
            audioSource.pitch = Random.Range(data.PitchRanges.x, data.PitchRanges.y);
            audioSource.spatialBlend = Random.Range(data.SpatialBlend.x, data.SpatialBlend.y);
            audioSource.Play();
            
            Object.Destroy(data.gameObject, audioSource.clip.length);
        }
    }
}