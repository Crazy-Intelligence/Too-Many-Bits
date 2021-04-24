using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CrazyIntelligence.Bits
{
	public static class GameManager
	{
		public static int WeightUntilGameOver { get; set; }

		public static event Action OnStart;
		public static event Action OnReset;

		public static event Action OnPause;
		public static event Action OnContinue;

		public static event Action OnGameOver;

		public static event Action OnAppExit;

		public static bool IsPlaying;
		public static bool IsPaused;

		public static void Start()
		{
			Counter.ResetAll();

			IsPlaying = true;

			OnStart?.Invoke();
		}
		public static void Restart()
		{
			if (IsPaused)
			{
				Continue();
			}

			OnReset?.Invoke();

			Start();
		}
		public static void Pause()
		{
			IsPaused = true;
			OnPause?.Invoke();
		}
		public static void Continue()
		{
			IsPaused = false;
			OnContinue?.Invoke();
		}
		public static void ExitApp()
		{
			OnAppExit?.Invoke();

			Application.Quit();

#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
#endif
		}

		public static bool CheckGameOver()
		{
			if (Counter.Weight >= WeightUntilGameOver)
			{
				IsPlaying = false;
				OnGameOver?.Invoke();
				return true;
			}

			return false;
		}
	}
}
