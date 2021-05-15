using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	[System.Serializable]
	public class Sequence
	{
		[SerializeField] private ActionsWithDelay[] sequence;

		private Timer _timer;

		private int _current;
		private bool _enabled;

		public void Start()
		{
			_enabled = true;
			_current = 0;

			SetupTimer();
		}
		public void TickTimer(float duration)
		{
			if (!_enabled) return;
			
			_timer.Tick(duration);
		}

		private void InvokeAction()
		{
			sequence[_current].Invoke();

			_current++;

			if (_current >= sequence.Length)
			{
				_enabled = false;
				return;
			}

			ResetTimer();
		}

		private void SetupTimer()
		{
			if (_timer is null)
			{
				var delay = sequence[_current].Delay;

				_timer = new Timer(delay);
				_timer.OnTimerEnd += InvokeAction;
			}
		}

		private void ResetTimer()
		{
			var delay = sequence[_current].Delay;

			_timer.Reset(delay);
		}
	}
}
