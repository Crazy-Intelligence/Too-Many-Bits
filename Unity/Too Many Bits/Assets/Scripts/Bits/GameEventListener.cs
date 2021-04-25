using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.Bits
{
	public class GameEventListener : MonoBehaviour
	{
		[SerializeField] private UnityEvent OnStartEvent;
		[SerializeField] private UnityEvent OnResetEvent;
		[SerializeField] private UnityEvent OnPauseEvent;
		[SerializeField] private UnityEvent OnContinueEvent;
		[SerializeField] private UnityEvent OnGameOverEvent;
		[SerializeField] private UnityEvent OnAppStartEvent;
		[SerializeField] private UnityEvent OnAppExitEvent;

		private void OnEnable()
		{
			GameManager.OnStart += OnStart;
			GameManager.OnReset += OnReset;
			GameManager.OnPause += OnPause;
			GameManager.OnContinue += OnContinue;
			GameManager.OnGameOver += OnGameOver;
			GameManager.OnAppStart += OnAppStart;
			GameManager.OnAppExit += OnAppExit;
		}
		private void OnDisable()
		{
			GameManager.OnStart -= OnStart;
			GameManager.OnReset -= OnReset;
			GameManager.OnPause -= OnPause;
			GameManager.OnContinue -= OnContinue;
			GameManager.OnGameOver -= OnGameOver;
			GameManager.OnAppStart -= OnAppStart;
			GameManager.OnAppExit -= OnAppExit;
		}

		private void OnStart() => OnStartEvent?.Invoke();
		private void OnReset() => OnResetEvent?.Invoke();
		private void OnPause() => OnPauseEvent?.Invoke();
		private void OnContinue() => OnContinueEvent?.Invoke();
		private void OnGameOver() => OnGameOverEvent?.Invoke();
		private void OnAppStart() => OnAppStartEvent?.Invoke();
		private void OnAppExit() => OnAppExitEvent?.Invoke();
	}
}
