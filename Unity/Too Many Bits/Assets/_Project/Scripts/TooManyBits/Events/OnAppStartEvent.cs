using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits.Events
{
	public class OnAppStartEvent : MonoBehaviour
	{
		[SerializeField] private UnityEvent OnAppStart;

		private void OnEnable()
		{
			GameManager.OnAppStart += InvokeEvent;
		}
		private void OnDisable()
		{
			GameManager.OnAppStart -= InvokeEvent;
		}

		private void InvokeEvent() => OnAppStart?.Invoke();
	}
}
