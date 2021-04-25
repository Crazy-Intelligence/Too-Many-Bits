using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class LevelManager : MonoBehaviour
	{
		public static List<Spawner> Spawner = new List<Spawner>();
		[Space]
		[SerializeField] private float startSpawnRate;
		[SerializeField] private float spawnRateIncreaseStepSize;
		[SerializeField] private float timeUntilStepup;

		private Timer _timer;

		private void Start()
		{
			_timer = new Timer(timeUntilStepup, true);
			_timer.OnTimerEnd += IncreaseSpawnRate;
			ResetSpawnRates();
		}

		private void OnEnable()
		{
			GameManager.OnStart += ResetSpawnRates;
		}
		private void OnDisable()
		{
			GameManager.OnStart -= ResetSpawnRates;
		}

		private void Update()
		{
			_timer.Tick(Time.deltaTime);
		}

		private void IncreaseSpawnRate()
		{
			foreach (var spawner in Spawner)
			{
				spawner.SetSpawnRate(spawner.spawnRate + spawnRateIncreaseStepSize);
			}
		}
		private void ResetSpawnRates()
		{
			foreach (var spawner in Spawner)
			{
				spawner.spawnRate = startSpawnRate;
			}
		}
	}
}
