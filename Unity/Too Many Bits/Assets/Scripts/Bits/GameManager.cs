using System;
using UnityEngine;

using Object = UnityEngine.Object;

namespace CrazyIntelligence.Bits
{
	public static class GameManager
	{
		public static int WeightUntilGameOver { get; set; }

		public static event Action OnGameStart;
		public static event Action OnGamePause;
		public static event Action OnGameContinue;
		public static event Action OnGameOver;

		public static event Action OnAppExit;

		public static void StartGame()
		{
			foreach (var bit in Object.FindObjectsOfType<Bit>())
			{
				Object.Destroy(bit.gameObject);
			}

			Counter.ResetAll();

			OnGameStart?.Invoke();
		}
		public static void PauseGame()
		{
			OnGamePause?.Invoke();
		}
		public static void ContinueGame()
		{
			OnGameContinue?.Invoke();
		}
		public static void ExitGame()
		{
			OnAppExit?.Invoke();

			Application.Quit();

#if UNITY_EDITOR
			Debug.Log("Game Exit");
#endif
		}

		public static bool CheckGameOver()
		{
			if (Counter.Weight >= WeightUntilGameOver)
			{
				OnGameOver?.Invoke();
				return true;
			}

			return false;
		}
	}
}
