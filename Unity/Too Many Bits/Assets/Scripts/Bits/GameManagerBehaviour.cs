using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.Bits
{
	public class GameManagerBehaviour : MonoBehaviour
	{
		[SerializeField] private int weightUntilGameOver;
		[SerializeField] private UnityEvent OnGameOverEvent;

		private float _timeScaleBeforePause;

		private void Awake()
		{
			GameManager.WeightUntilGameOver = weightUntilGameOver;
		}

		private void OnEnable()
		{
			GameManager.OnGamePause -= OnGamePause;
			GameManager.OnGameContinue -= OnGameContinue;
		}
		private void OnDisable()
		{
			GameManager.OnGamePause -= OnGamePause;
			GameManager.OnGameContinue -= OnGameContinue;
		}

		private void Update()
		{
			if (GameManager.CheckGameOver())
			{
				OnGameOverEvent?.Invoke();
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				GameManager.PauseGame();
			}
		}

		private void OnGamePause()
		{
			_timeScaleBeforePause = Time.timeScale;
			TimeManager.SetTimeScale(0);
		}
		private void OnGameContinue()
		{
			TimeManager.SetTimeScale(_timeScaleBeforePause);
		}
	}
}
