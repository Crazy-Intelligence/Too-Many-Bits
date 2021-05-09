using System;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[CreateAssetMenu(fileName = "DynamicWave", menuName = "TooManyBits/Wave/Single/Dynamic")]
	public class DynamicWave : Wave
	{
		[SerializeField] private BasicWave baseWave;

		[SerializeField] private float spawnRateIncrease;
		[SerializeField] private float maxSpawnRate;

		[SerializeField] [HideInInspector] private float[] origionalSpawnRates;

		private int ConfigCount => baseWave.Configurations.Length;

		public override void ApplyBase()
		{
			LoadOriginalSpawnRates();

			baseWave.Apply();
		}
		
		public override void ApplyNext()
		{
			ModifySpawnRates(Increase);
			baseWave.Apply();
		}

		private void ModifySpawnRates(Func<float, float> modifier)
		{
			if (origionalSpawnRates.Length == 0)
			{
				SaveOriginalSpawnRates();
			}

			for (int i = 0; i < ConfigCount; i++)
			{
				var config = baseWave.Configurations[i];

				config.SpawnRate = modifier(config.SpawnRate);
			}
		}

		private void SaveOriginalSpawnRates()
		{
			origionalSpawnRates = new float[ConfigCount];

			for (int i = 0; i < ConfigCount; i++)
			{
				var config = baseWave.Configurations[i];
				origionalSpawnRates[i] = config.SpawnRate;
			}
		}
		private void LoadOriginalSpawnRates()
		{
			for (int i = 0; i < ConfigCount; i++)
			{
				var config = baseWave.Configurations[i];
				config.SpawnRate = origionalSpawnRates[i];
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
	}
}
