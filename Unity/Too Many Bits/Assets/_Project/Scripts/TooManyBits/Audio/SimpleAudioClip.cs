using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Audio
{
	[CreateAssetMenu(fileName = "SimpleAudioClip", menuName = "TooManyBits/Audio/Simple")]
	public class SimpleAudioClip : ConfiguredAudioClip
	{
		[SerializeField] private AudioClip clip;
		[Space]
		[SerializeField] [Range(0f, 1f)] private float volume = 1f;
		[SerializeField] [Range(-3f, 3f)] private float pitch = 1f;

		public override void Play(AudioSource source)
		{
			source.clip = clip;
			source.volume = volume;
			source.pitch = pitch;
			source.Play();
		}
	}
}
