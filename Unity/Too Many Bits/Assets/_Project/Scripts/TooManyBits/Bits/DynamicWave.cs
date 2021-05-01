using System;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "DynamicWave", menuName = "TooManyBits/Wave/Dynamic")]
	public class DynamicWave : Wave
	{
		[SerializeField] private SimpleWave baseWave;

		[SerializeField] private float spawnRateIncrease;
		[SerializeField] private float maxSpawnRate;

		private SimpleWave _currentWave;

		private void OnEnable()
		{
			if (baseWave is null) return;

			_currentWave = CreateInstance<SimpleWave>();
			_currentWave.Configurations = baseWave.Configurations;
		}

		public override void ApplyNextWave()
		{
			ModifySpawnRates(Increase);
			_currentWave.Apply();
		}

		public override void ApplyPreviousWave()
		{
			ModifySpawnRates(Decrease);
			_currentWave.Apply();
		}

		private void ModifySpawnRates(Func<float, float> modifier)
		{
			foreach (var config in _currentWave.Configurations)
			{
				foreach (var spawner in config.Spawners)
				{
					spawner.SpawnRate = modifier(spawner.SpawnRate);
				}
			}
		}

		private float Increase(float currentSpawnRate)
		{
			var increasedSpawnRate = currentSpawnRate + spawnRateIncrease;

			if (increasedSpawnRate > maxSpawnRate)
			{
				return maxSpawnRate;
			}

			return increasedSpawnRate;
		}
		private float Decrease(float currentSpawnRate)
		{
			var decreasedSpawnRate = currentSpawnRate - spawnRateIncrease;

			if (decreasedSpawnRate < 0f)
			{
				return 0f;
			}

			return decreasedSpawnRate;
		}
	}
}
