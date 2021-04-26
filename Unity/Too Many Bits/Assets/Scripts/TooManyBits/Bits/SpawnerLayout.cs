using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "SpawnerLayout", menuName = "TooManyBits/Spawner/Layout")]
	public class SpawnerLayout : ScriptableObject
	{
		public List<SpawnerInfo> spawners = new List<SpawnerInfo>();
	}
}
