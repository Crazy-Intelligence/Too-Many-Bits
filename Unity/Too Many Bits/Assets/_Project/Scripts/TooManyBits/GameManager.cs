using System;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits
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
		
		public static bool IsPlaying { get; private set; }

		public static void Start()
		{
			IsPlaying = true;

			OnStart?.Invoke();
		}
		public static void Reset()
		{
			IsPlaying = false;

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

		public static void DoGameOver()
		{
			if (!IsPlaying) return;

			IsPlaying = false;
			OnGameOver?.Invoke();
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
			UnityEditor.EditorApplication.isPlaying = false;
#endif
		}
	}
}
