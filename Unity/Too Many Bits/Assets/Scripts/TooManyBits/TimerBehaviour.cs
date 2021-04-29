using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits
{
	public class TimerBehaviour : MonoBehaviour
	{
		[SerializeField] private float duration;
		[SerializeField] private bool loop;

		[SerializeField] private UnityEvent OnTimerEnd;

		private Timer _timer;

		private void Start()
		{
			_timer = new Timer(duration, loop);
			_timer.OnTimerEnd += InvokeOnTimerEnd;

		}

		private void Update()
		{
			_timer.Tick(Time.deltaTime);
		}

		private void InvokeOnTimerEnd() => OnTimerEnd?.Invoke();
	}
}
