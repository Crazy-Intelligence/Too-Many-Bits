using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits
{
	public class TimerBehaviour : MonoBehaviour
	{
		[SerializeField] private float duration;
		[SerializeField] private bool loop;
		[SerializeField] private bool useUnscaledTime;
		[SerializeField] private bool enableOnStart;
		[SerializeField] private UnityEvent OnTimerEnd;

		private bool _enabled;

		private Timer _timer;

		private void Start()
		{
			_timer = new Timer(duration, loop);
			_timer.OnTimerEnd += InvokeOnTimerEnd;

			_enabled = enableOnStart;
		}

		private void Update()
		{
			if (!_enabled) return;

			if (useUnscaledTime)
			{
				_timer.Tick(Time.unscaledDeltaTime);
			}
			else
			{
				_timer.Tick(Time.deltaTime);
			}
		}

		public void StartTimer()
		{
			_enabled = true;
		}

		private void InvokeOnTimerEnd() => OnTimerEnd?.Invoke();
	}
}
