using UnityEngine;
using CrazyIntelligence.TooManyBits.Bits;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[System.Serializable]
	public class TargetGroup
	{
		public SpawnerConfig[] Spawners;

		public void ApplyChanges(float spawnRate, WeightedList<BitConfig> bits)
		{
			foreach (var spawner in Spawners)
			{
				spawner.SpawnRate = spawnRate;
				spawner.Bits = bits;
			}
			SpawnerConfig.UpdateAll();
		}
	}
}
