using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "Spawner", menuName = "TooManyBits/Spawner/Config")]
	public class SpawnerConfig : ScriptableObject
	{
		public bool disabled;
		[Space]
		[Range(0, 100)] public float SpawnRate;
		[Space]
		[Range(50f, 150f)] public float SpawnForce;
		[Range(0f, 89f)] public float SpawnRange;
		[Space]
		public BitCollection objectInfo;
	}
}
