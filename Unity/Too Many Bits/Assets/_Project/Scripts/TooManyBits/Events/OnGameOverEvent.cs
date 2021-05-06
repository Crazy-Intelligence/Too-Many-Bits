using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits.Events
{
	public class OnGameOverEvent : MonoBehaviour
	{
		[SerializeField] private UnityEvent OnGameOver;

		private void OnEnable()
		{
			GameManager.OnGameOver += InvokeEvent;
		}
		private void OnDisable()
		{
			GameManager.OnGameOver -= InvokeEvent;
		}

		private void InvokeEvent() => OnGameOver?.Invoke();
	}
}
