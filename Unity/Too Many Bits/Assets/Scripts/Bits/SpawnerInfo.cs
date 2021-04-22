using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[CreateAssetMenu(fileName = "Spawner", menuName = "Bits/SpawnerInfo")]
	public class SpawnerInfo : ScriptableObject
	{
		[Range(1f, 25f)] public float SpawnForce;
		[Range(-179f, 179f)] public float SpawnDirection;
		[Range(0f, 89f)] public float SpawnRange;
	}
}
