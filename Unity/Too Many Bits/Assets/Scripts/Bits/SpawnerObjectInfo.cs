using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[CreateAssetMenu(fileName = "SpawnerObjectInfo", menuName = "Bits/SpawnerObjectInfo")]
	public class SpawnerObjectInfo : ScriptableObject
	{
		public GameObject Prefab;
		public List<ObjectWithWeight<BitData>> Distribution = new List<ObjectWithWeight<BitData>>();
	}
}
