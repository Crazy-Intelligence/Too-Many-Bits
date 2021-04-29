using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "Wave", menuName = "TooManyBits/Spawner/Wave")]
	public class Wave : ScriptableObject
	{
		[SerializeField] private List<WaveConfig> waveConfigs = new List<WaveConfig>();

		[ContextMenu("Apply")]
		public void Apply()
		{
			foreach (var config in waveConfigs)
			{
				config.Apply();
			}
		}
	}
}
