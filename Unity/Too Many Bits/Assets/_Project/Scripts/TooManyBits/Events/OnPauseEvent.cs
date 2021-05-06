using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits.Events
{
	public class OnPauseEvent : MonoBehaviour
	{
		[SerializeField] private UnityEvent OnPause;

		private void OnEnable()
		{
			GameManager.OnPause += InvokeEvent;
		}
		private void OnDisable()
		{
			GameManager.OnPause -= InvokeEvent;
		}

		private void InvokeEvent() => OnPause?.Invoke();
	}
}
