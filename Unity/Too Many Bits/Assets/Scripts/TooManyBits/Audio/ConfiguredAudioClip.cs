using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Audio
{
	public abstract class ConfiguredAudioClip : ScriptableObject
	{
		public abstract void Play(AudioSource source);
	}
}
