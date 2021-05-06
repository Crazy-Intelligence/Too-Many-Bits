using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits.Events
{
	public class OnResetEvent : MonoBehaviour
	{
		[SerializeField] private UnityEvent OnReset;

		private void OnEnable()
		{
			GameManager.OnReset += InvokeEvent;
		}
		private void OnDisable()
		{
			GameManager.OnReset -= InvokeEvent;
		}

		private void InvokeEvent() => OnReset?.Invoke();
	}
}
