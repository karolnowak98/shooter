using UnityEngine;

namespace GlassyCode.Shooter.Core.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceData : MonoBehaviour
    {
        [Tooltip("Volume range of the sound.")]
        [SerializeField]
        private Vector2 _volumeRanges;

        [Tooltip("Pitch range of the sound.")]
        [SerializeField]
        private Vector2 _pitchRanges;

        [Tooltip("Transition between 2D and 3D sound.")]
        [SerializeField]
        private Vector2 _spatialBlend;

        public AudioSource AudioSource { get; private set; }
        
        private void Awake()
        {
            AudioSource = GetComponent<AudioSource>();
        }

        public Vector2 VolumeRanges => _volumeRanges;
        public Vector2 PitchRanges => _pitchRanges;
        public Vector2 SpatialBlend => _spatialBlend;
    }
}