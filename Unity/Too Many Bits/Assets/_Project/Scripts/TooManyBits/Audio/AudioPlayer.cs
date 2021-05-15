using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Audio
{
	[RequireComponent(typeof(AudioSource))]
	public class AudioPlayer : MonoBehaviour
	{
		[SerializeField] private GameSettings settings;
		[SerializeField] private AudioType audioType;

		private AudioSource _source;

		public void Play(ConfiguredAudioClip clip)
		{
			if (_source is null)
			{
				_source = GetComponent<AudioSource>();
			}

			clip.Play(_source);

			AdjustVolume();
		}

		private void AdjustVolume()
		{
			var subVolume = 0f;

			switch (audioType)
			{
				case AudioType.Music:
					subVolume = settings.MusicVolume;
					break;
				case AudioType.Sound:
					subVolume = settings.SoundVolume;
					break;
			}

			_source.volume *= settings.MasterVolume * subVolume;
		}
	}
}