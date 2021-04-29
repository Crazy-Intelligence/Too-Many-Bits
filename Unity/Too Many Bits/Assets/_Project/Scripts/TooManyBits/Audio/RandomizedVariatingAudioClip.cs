using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Audio
{
	[CreateAssetMenu(fileName = "VariatingAudioClips", menuName = "TooManyBits/Audio/RandomVariating")]
	public class RandomizedVariatingAudioClip : ConfiguredAudioClip
	{
		[SerializeField] private WeightedList<VariatingAudioClip> clips;

		public override void Play(AudioSource source)
		{
			clips.GetRandom().Play(source);
		}
	}
}
