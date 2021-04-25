using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(Animator))]
	public class UIElement : MonoBehaviour
	{
		private Animator _animator;

		private Timer _timer;
		private bool _waiting;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}
		private void Update()
		{
			if (!_waiting) return;

			_timer.Tick(Time.unscaledDeltaTime);
		}

		[ContextMenu("Show")]
		public void Show()
		{
			_animator.SetBool("Show", true);
			_waiting = false;
		}
		public void ShowAfter(float timeout)
		{
			_timer = new Timer(timeout);
			_timer.OnTimerEnd += Show;
			_waiting = true;
		}
		[ContextMenu("Hide")]
		public void Hide()
		{
			_animator.SetBool("Show", false);
			_waiting = false;
		}
		public void HideAfter(float timeout)
		{
			_timer = new Timer(timeout);
			_timer.OnTimerEnd += Hide;
			_waiting = true;
		}
	}
}
