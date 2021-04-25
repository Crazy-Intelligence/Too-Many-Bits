using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CrazyIntelligence.Bits
{
	public static class GameManager
	{
		public static event Action OnStart;
		public static event Action OnReset;

		public static event Action OnPause;
		public static event Action OnContinue;

		public static event Action OnGameOver;

		public static event Action OnAppStart;
		public static event Action OnAppExit;
		
		public static int WeightUntilGameOver { get; set; }

		public static bool IsPlaying { get; private set; }

		public static void Start()
		{
			IsPlaying = true;

			OnStart?.Invoke();
		}
		public static void Reset()
		{
			IsPlaying = false;

			Counter.ResetAll();

			OnReset?.Invoke();
		}
		public static void Pause()
		{
			IsPlaying = false;

			OnPause?.Invoke();
		}
		public static void Continue()
		{
			IsPlaying = true;

			OnContinue?.Invoke();
		}
		public static void StartApp()
		{
			IsPlaying = false;

			OnAppStart?.Invoke();
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
			if (!IsPlaying) return false;

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
