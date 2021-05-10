using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	public class WaveManager : MonoBehaviour
	{
		[SerializeField] private WaveLayout layout;

		private Timer _timer;

		private int _currentIndex;
		private bool _disabled;

		private void Start()
		{
			_timer = new Timer(0f);
			_timer.OnTimerEnd += NextWave;

			Disable();
		}
		private void Update()
		{
			if (_disabled) return;
			_timer.Tick(Time.deltaTime);
		}

		public void Disable()
		{
			_disabled = true;
			layout.Disabled.Apply();
		}
		public void Enable()
		{
			_disabled = false;
			StartWave(_currentIndex);
		}

		public void FirstWave()
		{
			_currentIndex = 0;
			StartWave(_currentIndex);
		}
		public void NextWave()
		{
			_currentIndex++;
			StartWave(_currentIndex);
		}

		private void StartWave(int index)
		{
			if (index >= layout.WaveCount) return;

			layout.Apply(index, out var duration);

			_timer.Reset(duration);
		}
	}
}
