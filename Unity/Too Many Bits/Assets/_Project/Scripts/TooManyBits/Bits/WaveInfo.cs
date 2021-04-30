using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[System.Serializable]
	public class WaveInfo
	{
		public SpawnerConfig[] Spawners;
		[SerializeField] [Range(0f, 100f)] private float SpawnRate;
		public BitCollection Bits;

		public void Apply()
		{
			foreach (var spawner in Spawners)
			{
				spawner.SpawnRate = SpawnRate;
				spawner.Bits = Bits;
			}
		}
	}
}
