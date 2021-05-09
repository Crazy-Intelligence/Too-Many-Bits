using CrazyIntelligence.TooManyBits.Bits;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[CreateAssetMenu(fileName = "Spawners", menuName = "TooManyBits/Wave/SpawnSettings")]
	public class SpawnSettings : ScriptableObject
	{
		[Range(0f, 200f)] public float SpawnRate;
		public WeightedList<BitConfig> Bits;
	}
}
