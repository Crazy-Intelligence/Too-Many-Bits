using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[CreateAssetMenu(fileName = "Layout", menuName = "TooManyBits/Waves/Layout")]
	public class WaveLayout : ScriptableObject
	{
		public Wave Disabled;
		public Wave[] Waves;
	}
}
