using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "SimpleWave", menuName = "TooManyBits/Wave/Simple")]
	public class SimpleWave : Wave
	{
		public WaveInfo[] Configurations;

		public void Apply()
		{
			foreach (var config in Configurations)
			{
				config.Apply();
			}
		}

		public override void ApplyNextWave() => Apply();
		public override void ApplyPreviousWave() => Apply();
	}
}
