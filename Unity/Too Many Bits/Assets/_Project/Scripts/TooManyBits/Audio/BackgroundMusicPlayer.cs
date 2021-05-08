using System.Collections;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Audio
{
	public class BackgroundMusicPlayer : MonoBehaviour
	{
		[SerializeField] private ConfiguredAudioClip gameTracks;
		[SerializeField] private ConfiguredAudioClip menuTracks;
		[Space]
		[SerializeField] private float transitionDuration;

		private AudioSource _source;

		private Timer _timer;

		private void Awake()
		{
			_source = GetComponent<AudioSource>();
			_timer = new Timer(transitionDuration);
		}

		public void PlayGameMusic()
		{
			StartCoroutine(ChangeTrack(gameTracks));
		}
		public void PlayMenuMusic()
		{
			StartCoroutine(ChangeTrack(menuTracks));
		}

		private IEnumerator ChangeTrack(ConfiguredAudioClip newTrack)
		{
			while (_timer.RemainingSeconds > 0f)
			{
				_source.volume = Mathf.Lerp(_source.volume, 0f, transitionDuration * Time.unscaledDeltaTime);

				_timer.Tick(Time.unscaledDeltaTime);
				yield return null;
			}
			newTrack.Play(_source);

			_timer.Reset();
		}
	}
}
