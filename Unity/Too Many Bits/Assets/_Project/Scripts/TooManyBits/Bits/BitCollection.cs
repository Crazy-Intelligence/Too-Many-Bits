using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "SpawnerObjectInfo", menuName = "TooManyBits/Bits/Collection")]
	public class BitCollection : ScriptableObject
	{
		[SerializeField] private WeightedList<BitConfig> BitConfigs;

		public BitConfig GetRandomConfig()
		{
			return BitConfigs.GetRandom();
		}
	}
}
