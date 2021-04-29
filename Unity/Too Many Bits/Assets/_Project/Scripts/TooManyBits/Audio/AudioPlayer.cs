using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Audio
{
	[RequireComponent(typeof(AudioSource))]
	public class AudioPlayer : MonoBehaviour
	{
		private AudioSource _source;

		public void Play(ConfiguredAudioClip clip)
		{
			if (_source is null)
			{
				_source = GetComponent<AudioSource>();
			}

			clip.Play(_source);
		}
	}
}
