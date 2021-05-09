using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[CreateAssetMenu(fileName = "BasicWave", menuName = "TooManyBits/Wave/Single/Basic")]
	public class BasicWave : Wave
	{
		public WaveConfig[] Configurations;

		public void Apply()
		{
			foreach (var config in Configurations)
			{
				config.Apply();
			}
		}

		public override void ApplyBase() => Apply();
		public override void ApplyNext() => Apply();
	}
}
