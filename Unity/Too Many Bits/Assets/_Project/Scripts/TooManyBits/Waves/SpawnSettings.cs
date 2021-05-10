using CrazyIntelligence.TooManyBits.Bits;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[System.Serializable]
	public class SpawnSettings
	{
		[Range(0f, 200f)] public float SpawnRate;
		public WeightedList<BitConfig> Bits;
	}
}
