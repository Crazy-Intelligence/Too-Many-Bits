using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	[CreateAssetMenu(fileName = "Spawner", menuName = "TooManyBits/Spawner/Config")]
	public class SpawnerConfig : ScriptableObject
	{
		[Range(0, 100)] public float spawnRate;
		[Range(1f, 25f)] public float SpawnForce;
		[Range(-179f, 179f)] public float SpawnDirection;
		[Range(0f, 89f)] public float SpawnRange;
	}
}
