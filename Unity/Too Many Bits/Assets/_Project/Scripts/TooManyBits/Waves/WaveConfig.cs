using CrazyIntelligence.TooManyBits.Bits;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[CreateAssetMenu(fileName = "WaveConfig", menuName = "TooManyBits/Waves/Config")]
	public class WaveConfig : ScriptableObject
	{
		public SpawnerConfig[] Targets;
		public WeightedList<BitConfig> Bits;
		[Range(0f, 200f)] public float SpawnRate;

		public void Apply()
		{
			foreach (var spawner in Targets)
			{
				spawner.SpawnRate = SpawnRate;
				spawner.Bits = Bits;
			}
		}
	}
}
