using System.Collections.Generic;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[System.Serializable]
	public class WaveConfig
	{
		public List<SpawnerConfig> Spawner = new List<SpawnerConfig>();
		public WaveInfo WaveInfo;

		public void Apply()
		{
			foreach (var spawner in Spawner)
			{
				spawner.WaveInfo = WaveInfo;
			}
		}
	}
}
