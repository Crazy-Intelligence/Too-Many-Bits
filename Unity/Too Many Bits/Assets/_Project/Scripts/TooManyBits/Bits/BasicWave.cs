using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "BasicWave", menuName = "TooManyBits/Wave/Basic")]
	public class BasicWave : Wave
	{
		public WaveInfo[] Configurations;

		public void Apply()
		{
			foreach (var config in Configurations)
			{
				config.Apply();
			}

			SpawnerConfig.UpdateAll();
		}

		public override void ApplyBase() => Apply();
		public override void ApplyNext() => Apply();
		public override void ApplyPrevious() => Apply();
	}
}
