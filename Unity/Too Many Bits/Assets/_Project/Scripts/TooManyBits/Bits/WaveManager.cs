using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class WaveManager : MonoBehaviour
	{
		[SerializeField] private WaveLayout waveLayout;
		[SerializeField] private Behaviour behaviour;
		[Space]
		[SerializeField] private float timeUntilNextWave;

		private Timer _timer;

		private void Start()
		{
			waveLayout.ApplyNextWave();
			if (behaviour == Behaviour.Static)
			{
				enabled = false;
			}

			_timer = new Timer(timeUntilNextWave, true);
			_timer.OnTimerEnd += OnTimerEnd;
		}
		private void Update()
		{
			if (behaviour != Behaviour.Timed) return;

			_timer.Tick(Time.deltaTime);
		}

		private void OnTimerEnd()
		{
			NextWave();
		}

		public void NextWave()
		{
			waveLayout.ApplyNextWave();
		}
		public void PreviousWave()
		{
			waveLayout.ApplyPreviousWave();
		}

		private enum Behaviour
		{
			Static,
			Timed,
			Triggered
		}
	}
}
