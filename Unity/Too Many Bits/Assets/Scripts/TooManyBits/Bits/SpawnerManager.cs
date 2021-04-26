using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class SpawnerManager : MonoBehaviour
	{
		public List<SpawnerLayout> Layouts = new List<SpawnerLayout>();

		[SerializeField] private float timeUntilStepup;

		private int _currentIndex;

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
			_currentIndex++;
		}
		private void UpdateLayout()
		{

		}
	}
}
