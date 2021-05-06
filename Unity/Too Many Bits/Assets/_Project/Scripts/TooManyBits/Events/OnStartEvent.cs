using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits.Events
{
	public class OnStartEvent : MonoBehaviour
	{
		[SerializeField] private UnityEvent OnStart;

		private void OnEnable()
		{
			GameManager.OnStart += InvokeEvent;
		}
		private void OnDisable()
		{
			GameManager.OnStart -= InvokeEvent;
		}

		private void InvokeEvent() => OnStart?.Invoke();
	}
}
