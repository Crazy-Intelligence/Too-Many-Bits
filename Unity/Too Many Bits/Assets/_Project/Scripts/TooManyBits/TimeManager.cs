using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits
{
	public class TimeManager : MonoBehaviour
	{
		public float SlowDuration;
		[Range(0.01f, 1f)] public float SlowTimeScale;

		[SerializeField] private UnityEvent OnSlowTime;
		[SerializeField] private UnityEvent OnNormalTime;

		private Timer _timer;

		private void Start()
		{
			_timer = new Timer(SlowDuration);
			_timer.OnTimerEnd += ResetTimeScale;
		}

		private void Update()
		{
			_timer.Tick(Time.unscaledDeltaTime);
		}
		
		public void SlowTime()
		{
			SetTimeScale(SlowTimeScale);
			_timer.Reset();
			OnSlowTime?.Invoke();
		}

		private void SetTimeScale(float timeScale)
		{
			Time.timeScale = timeScale;
			Time.fixedDeltaTime = Time.timeScale * 0.02f;
		}
		private void ResetTimeScale()
		{
			SetTimeScale(1f);
			OnNormalTime?.Invoke();
		}
	}
}
