using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "SpawnerObjectInfo", menuName = "TooManyBits/Bits/Collection")]
	public class BitCollection : ScriptableObject
	{
		public GameObject Prefab;
		[SerializeField] private WeightedList<BitConfig> BitConfigs;

		public BitConfig GetRandomConfig()
		{
			return BitConfigs.GetRandom();
		}
	}
}
