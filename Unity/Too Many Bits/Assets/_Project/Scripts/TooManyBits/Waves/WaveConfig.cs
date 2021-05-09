using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[System.Serializable]
	public class WaveConfig
	{
		[SerializeField] private TargetGroup Targets;
		[SerializeField] private SpawnSettings SpawnSettings;

		public float SpawnRate { get => SpawnSettings.SpawnRate; set => SpawnSettings.SpawnRate = value; }

		public void Apply()
		{
			Targets.ApplyChanges(SpawnSettings.SpawnRate, SpawnSettings.Bits);
		}
	}
}
