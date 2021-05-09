using System;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "Spawner", menuName = "TooManyBits/Spawner/Config")]
	public class SpawnerConfig : ScriptableObject
	{
		public GameObject Prefab;
		[Space]
		[Range(50f, 150f)] public float SpawnForce;
		[Space]
		[Range(0f, 89f)] public float SpawnAngelRange;
		[Range(0, 179f)] public float SpawnAngelOffset;
		[Space]
		[SerializeField] private float _spawnRateDeviation;
		
		public float SpawnRate;
		public WeightedList<BitConfig> Bits;

		public float SpawnTime => 1f / SpawnRate + UnityEngine.Random.Range(_spawnRateDeviation / -2f, _spawnRateDeviation / 2f);
		public bool Disabled => SpawnRate == 0;

		public static event Action OnConfigsUpdated;

		public static void UpdateAll() => OnConfigsUpdated?.Invoke();
	}
}
