using System;

namespace CrazyIntelligence.TooManyBits
{
	public class Timer
	{
		public float RemainingSeconds { get; private set; }
		public float CountedSeconds { get; private set; }

		public event System.Action OnTimerEnd;

		private float _duration;
		private bool _loop;

		public Timer(float duration, bool loop) => Initialize(duration, loop);
		public Timer(float duration) => Initialize(duration, false);

		public void Tick(float deltaTime)
		{
			CountedSeconds += deltaTime;

			if (RemainingSeconds <= 0f)
			{ return; }

			RemainingSeconds -= deltaTime;

			CheckTimerEnd();
		}

		public void Reset()
		{
			RemainingSeconds = _duration;
			CountedSeconds = 0f;
		}

		private void Initialize(float duration, bool loop)
		{
			RemainingSeconds = duration;
			_duration = duration;

			_loop = loop;
		}

		private void CheckTimerEnd()
		{
			if (RemainingSeconds > 0f) { return; }

			RemainingSeconds = 0f;

			OnTimerEnd?.Invoke();

			if (_loop) { Reset(); }
		}
	}
}
