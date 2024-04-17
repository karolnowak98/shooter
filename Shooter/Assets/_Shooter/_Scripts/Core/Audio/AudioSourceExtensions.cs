using UnityEngine;

namespace GlassyCode.Shooter.Core.Audio
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
        
        public static void Play(this AudioSourceData audioSourceData)
        {
            var parent = audioSourceData.transform;
            var data = Object.Instantiate(audioSourceData, parent.position, parent.rotation);
            var audioSource = data.AudioSource;
            
            audioSource.volume = Random.Range(data.VolumeRanges.x, data.VolumeRanges.y);
            audioSource.pitch = Random.Range(data.PitchRanges.x, data.PitchRanges.y);
            audioSource.spatialBlend = Random.Range(data.SpatialBlend.x, data.SpatialBlend.y);
            audioSource.Play();
            
            Object.Destroy(data.gameObject, audioSource.clip.length);
        }
    }
}