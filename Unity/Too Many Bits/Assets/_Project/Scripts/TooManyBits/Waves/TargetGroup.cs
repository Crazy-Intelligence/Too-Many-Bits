using UnityEngine;
using CrazyIntelligence.TooManyBits.Bits;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[CreateAssetMenu(fileName = "Spawners", menuName = "TooManyBits/Spawner/WaveTargetGroup")]
	public class TargetGroup : ScriptableObject
	{
		public SpawnerConfig[] Spawners;

		public void ApplyChanges(float spawnRate, BitCollection bits)
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
