using UnityEngine;
using GlassyCode.Shooter.Core.Audio;

namespace GlassyCode.Shooter.Game.Props.Logic
{
    public class PlayAudioReaction : DestroyReaction
    {
        [SerializeField] private AudioSourceData _audioSourceData;

        protected override void Awake()
        {
            base.Awake();
            
            if (_audioSourceData is null)
            {
                Debug.LogError(nameof(AudioSourceData) + " cannot be null!!");
            }
        }

        protected override void HandleDestroyReaction()
        {
            _audioSourceData.Play(transform);
        }
    }
}