using UnityEngine;
using MY.Utils;

namespace MY.Audio
{
    [CreateAssetMenu(menuName = "MY/Audio/Simple")]
    public class SimpleAudioEvent : AudioEvent
    {
        public AudioClip[] clips;

        public RangedFloat volume;

        [MinMaxRange(0, 2)]
        public RangedFloat pitch;

        public override void Play(AudioSource source)
        {
            if (clips.Length == 0)
                return;

            source.clip = clips[Random.Range(0, clips.Length)];
            source.volume = Random.Range(volume.minValue, volume.maxValue);
            source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
            source.Play();
        }
    }
}