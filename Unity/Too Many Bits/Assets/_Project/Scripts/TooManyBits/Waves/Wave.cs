using CrazyIntelligence.TooManyBits.Bits;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[System.Serializable]
	public class Wave
	{
		[SerializeField] private WaveConfig[] configurations;
		public float Duration;

		public void Apply()
		{
			foreach (var config in configurations)
			{
				config.Apply();
			}

			SpawnerConfig.UpdateAll();
		}
	}
}
