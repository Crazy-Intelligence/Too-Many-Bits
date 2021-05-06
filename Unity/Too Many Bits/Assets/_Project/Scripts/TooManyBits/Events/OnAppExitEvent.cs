using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits.Events
{
	public class OnAppExitEvent : MonoBehaviour
	{
		[SerializeField] private UnityEvent OnAppExit;

		private void OnEnable()
		{
			GameManager.OnAppExit += InvokeEvent;
		}
		private void OnDisable()
		{
			GameManager.OnAppExit -= InvokeEvent;
		}

		private void InvokeEvent() => OnAppExit?.Invoke();
	}
}
