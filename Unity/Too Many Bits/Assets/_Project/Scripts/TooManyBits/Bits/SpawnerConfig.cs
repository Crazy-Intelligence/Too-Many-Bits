using System;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "Spawner", menuName = "TooManyBits/Spawner/Config")]
	public class SpawnerConfig : ScriptableObject
	{
		[Range(50f, 150f)] public float SpawnForce;
		[Space]
		[Range(0f, 89f)] public float SpawnAngelRange;
		[Range(0, 179f)] public float SpawnAngelOffset;
		[Space]
		public float SpawnRate;
		public BitCollection Bits;

		public float SpawnTime => 1f / SpawnRate;
		public bool Disabled => SpawnRate == 0;
	}
}
