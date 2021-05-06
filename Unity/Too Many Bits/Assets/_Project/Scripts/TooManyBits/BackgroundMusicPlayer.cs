using System.Collections;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	[RequireComponent(typeof(AudioSource))]
	public class BackgroundMusicPlayer : MonoBehaviour
	{
		[SerializeField] private AudioClip defaultClip;
		[Space]
		[SerializeField] private float transitionDuration;

		private AudioSource _audioSource;

		private void Start()
		{
			_audioSource.clip = defaultClip;
		}

		public void ChangeAudioClip(AudioClip clip)
		{
			StartCoroutine(ChangeClip(clip, transitionDuration));
		}

		private IEnumerator ChangeClip(AudioClip clip, float transitionTime)
		{
			var fadeTime = new WaitForSeconds(transitionTime / 2f);

			_audioSource.volume = Mathf.Lerp(1f, 0f, transitionTime / 2f);

			yield return fadeTime;

			_audioSource.clip = clip;

			_audioSource.volume = Mathf.Lerp(0f, 1f, transitionTime / 2);

			yield return fadeTime;
		}
	}
}
