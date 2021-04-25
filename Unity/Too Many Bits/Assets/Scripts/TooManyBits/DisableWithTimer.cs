using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class DisableWithTimer : MonoBehaviour
	{
		[SerializeField] private float time;

		private Timer _timer;

		private bool _active;

		private void Start()
		{
			_timer = new Timer(time);
			_timer.OnTimerEnd += OnTimerEnd;
		}

		private void Update()
		{
			if (!_active) return;

			_timer.Tick(Time.unscaledDeltaTime);
		}

		public void Disable()
		{
			_active = true;
		}

		private void OnTimerEnd()
		{
			gameObject.SetActive(false);
		}
	}
}
