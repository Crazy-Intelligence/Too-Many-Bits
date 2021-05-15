using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	public class GameEventListener : MonoBehaviour
	{
		[SerializeField] private bool useUnscaledTime;
		[Header("Events")]
		[SerializeField] private Sequence OnStart;
		[SerializeField] private Sequence OnReset;
		[SerializeField] private Sequence OnPause;
		[SerializeField] private Sequence OnContinue;
		[SerializeField] private Sequence OnGameOver;
		[SerializeField] private Sequence OnAppStart;
		[SerializeField] private Sequence OnAppExit;

		private void OnEnable()
		{
			GameManager.OnStart += InvokeOnStart;
			GameManager.OnReset += InvokenReset;
			GameManager.OnPause += InvokeOnPause;
			GameManager.OnContinue += InvokeOnContinue;
			GameManager.OnGameOver += InvokeOnGameOver;
			GameManager.OnAppStart += InvokeOnAppStart;
			GameManager.OnAppExit += InvokeOnAppExit;
		}
		private void OnDisable()
		{
			GameManager.OnStart -= InvokeOnStart;
			GameManager.OnReset -= InvokenReset;
			GameManager.OnPause -= InvokeOnPause;
			GameManager.OnContinue -= InvokeOnContinue;
			GameManager.OnGameOver -= InvokeOnGameOver;
			GameManager.OnAppStart -= InvokeOnAppStart;
			GameManager.OnAppExit -= InvokeOnAppExit;
		}

		private void Update()
		{
			float deltaTime;

			if (useUnscaledTime)
				deltaTime = Time.unscaledDeltaTime;
			else
				deltaTime = Time.deltaTime;

			OnStart.TickTimer(deltaTime);
			OnReset.TickTimer(deltaTime);
			OnPause.TickTimer(deltaTime);
			OnContinue.TickTimer(deltaTime);
			OnGameOver.TickTimer(deltaTime);
			OnAppStart.TickTimer(deltaTime);
			OnAppExit.TickTimer(deltaTime);
		}

		private void InvokeOnStart() => OnStart.Start();
		private void InvokenReset() => OnReset.Start();
		private void InvokeOnPause() => OnPause.Start();
		private void InvokeOnContinue() => OnContinue.Start();
		private void InvokeOnGameOver() => OnGameOver.Start();
		private void InvokeOnAppStart() => OnAppStart.Start();
		private void InvokeOnAppExit() => OnAppExit.Start();
	}
}
