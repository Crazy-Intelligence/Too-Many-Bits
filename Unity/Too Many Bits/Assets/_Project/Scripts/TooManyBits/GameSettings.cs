using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	[CreateAssetMenu(fileName = "Settings", menuName = "TooManyBits/Settings")]
	public class GameSettings : ScriptableObject
	{
		[Header("Audio")]
		[Range(0f, 1f)] public float MasterVolume;
		[Range(0f, 1f)] public float MusicVolume;
		[Range(0f, 1f)] public float SoundVolume;
	}
}
