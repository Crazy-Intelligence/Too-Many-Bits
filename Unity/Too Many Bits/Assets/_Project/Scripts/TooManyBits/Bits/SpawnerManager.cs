using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class SpawnerManager : MonoBehaviour
	{
		[SerializeField] private WaveLayout WaveLayout;

		[SerializeField] private float timeUntilStepup;

		private Timer _timer;

		private void Start()
		{
			_timer = new Timer(timeUntilStepup, true);
			_timer.OnTimerEnd += NextLayout;
		}

		private void Update()
		{
			_timer.Tick(Time.deltaTime);
		}

		private void NextLayout()
		{
			
		}
		private void UpdateLayout()
		{

		}
	}
}
