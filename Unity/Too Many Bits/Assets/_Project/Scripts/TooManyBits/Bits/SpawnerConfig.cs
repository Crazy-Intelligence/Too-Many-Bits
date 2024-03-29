using System;
using UnityEngine;
using CI.Collections;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "Spawner", menuName = "TooManyBits/Spawner/Config")]
	public class SpawnerConfig : ScriptableObject
	{
		public GameObject Prefab;
		[Space]
		public string StartLayer;
		[Space]
		public float SpawnForce;
		[Space]
		[Range(0f, 89f)] public float SpawnAngelRange;
		[Range(0, 179f)] public float SpawnAngelOffset;
		[Space]
		[SerializeField] private float _spawnRateDeviation;
		
		public float SpawnRate;
		public WeightedList<BitConfig> Bits;

		public float SpawnTime => 1f / SpawnRate + UnityEngine.Random.Range(_spawnRateDeviation / -2f, _spawnRateDeviation / 2f);
		public bool Disabled => SpawnRate == 0 || GameManager.IsPlaying == false;

		public static event Action OnConfigsUpdated;

		public static void UpdateAll() => OnConfigsUpdated?.Invoke();
	}
}
