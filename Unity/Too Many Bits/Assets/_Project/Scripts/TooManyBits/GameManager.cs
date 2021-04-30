using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

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

			ResetEvents();

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

		private static void ResetEvents()
		{
			var events = new Action[] { OnStart, OnReset, OnPause, OnContinue, OnGameOver, OnAppStart, OnAppExit };

			for (int i = 0; i < events.Length; i++)
			{
				var @event = events[i];
				var delegates = @event.GetInvocationList();

				for (int j = 0; j < delegates.Length; j++)
				{
					var @delegate = delegates[j];
					@event -= (Action)@delegate;
				}
			}
		}
	}
}
