using System;
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
			if (_current >= sequence.Length)
			{
				_enabled = false;
				return;
			}

			sequence[_current].Invoke();

			_timer.Reset(sequence[_current].Delay);

			_current++;
		}

		private void SetupTimer()
		{
			if (_timer is null)
			{
				_timer = new Timer(sequence[_current].Delay);
				_timer.OnTimerEnd += InvokeAction;
			}
		}
	}
}
