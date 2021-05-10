using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[CreateAssetMenu(fileName = "Wave", menuName = "TooManyBits/Waves/Wave")]
	public class Wave : ScriptableObject
	{
		public WaveConfig[] Configurations;

		public void Apply()
		{
			foreach (var config in Configurations)
			{
				config.Apply();
			}
		}
	}
}
