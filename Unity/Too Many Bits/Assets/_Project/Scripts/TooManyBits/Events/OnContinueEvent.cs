using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits.Events
{
	public class OnContinueEvent : MonoBehaviour
	{
		[SerializeField] private UnityEvent OnContinue;

		private void OnEnable()
		{
			GameManager.OnContinue += InvokeEvent;
		}
		private void OnDisable()
		{
			GameManager.OnContinue -= InvokeEvent;
		}

		private void InvokeEvent() => OnContinue?.Invoke();
	}
}
