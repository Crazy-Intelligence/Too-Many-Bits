using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "WaveInfo", menuName = "TooManyBits/Spawner/WaveInfo")]
	public class WaveInfo : ScriptableObject
	{
		public bool disabled;
		[Range(0, 100)] public float SpawnRate;
		public BitCollection objectInfo;
	}
}
