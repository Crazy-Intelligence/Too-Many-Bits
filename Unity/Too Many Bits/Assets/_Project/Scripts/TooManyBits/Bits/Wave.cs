using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "SimpleWave", menuName = "TooManyBits/Wave/Simple")]
	public class Wave : ScriptableObject
	{
		public WaveInfo[] configuration;

		public void Apply()
		{
			foreach (var config in configuration)
			{
				config.Apply();
			}
		}
	}
}
