using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "SpawnerObjectInfo", menuName = "TooManyBits/Bits/Collection")]
	public class BitCollection : ScriptableObject
	{
		public GameObject BitPrefab;
		[SerializeField] private List<ObjectWithWeight<BitConfig>> BitConfigs = new List<ObjectWithWeight<BitConfig>>();

		public BitConfig GetRandomConfig()
		{
			var objects = new List<BitConfig>();

			foreach (var obj in BitConfigs)
			{
				for (int i = 0; i < obj.Weight; i++)
				{
					objects.Add(obj.Object);
				}
			}

			var randomIndex = Random.Range(0, objects.Count - 1);

			return objects[randomIndex];
		}
	}
}
