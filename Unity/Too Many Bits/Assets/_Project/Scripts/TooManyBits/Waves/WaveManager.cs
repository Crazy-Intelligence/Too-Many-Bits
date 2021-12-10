using UnityEngine;
using CI.Utilities;

namespace CrazyIntelligence.TooManyBits.Waves
{
	public class WaveManager : MonoBehaviour
	{
		[SerializeField] private WaveLayout layout;

		private Timer _timer;

		private int _currentIndex;
		private bool _disabled;

		private void Awake()
		{
			_timer = new Timer(0f);
			_timer.OnTimerEnd += NextWave;
		}
		private void Start()
		{
			Disable();
		}
		private void Update()
		{
			if (_disabled) return;
			_timer.Tick(Time.deltaTime);
		}

		[ContextMenu("Disable")]
		public void Disable()
		{
			_disabled = true;
			layout.Disabled.Apply();
		}
		[ContextMenu("Enable")]
		public void Enable()
		{
			_disabled = false;
			StartWave(_currentIndex);
		}

		[ContextMenu("FirstWave")]
		public void FirstWave()
		{
			_currentIndex = 0;
			StartWave(_currentIndex);
		}
		[ContextMenu("NextWave")]
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
