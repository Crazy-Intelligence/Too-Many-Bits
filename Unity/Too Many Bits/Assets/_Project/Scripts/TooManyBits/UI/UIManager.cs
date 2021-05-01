using UnityEngine;

namespace CrazyIntelligence.TooManyBits.UI
{
	public class UIManager : MonoBehaviour
	{
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				if (GameManager.IsPlaying)
				{
					GameManager.Pause();
				}
				else
				{
					GameManager.Continue();
				}
			}

#if UNITY_EDITOR
			Cursor.lockState = CursorLockMode.None;
#else
			Cursor.lockState = CursorLockMode.Confined;
#endif
		}

		public void Play() => GameManager.Start();
		public void Restart() => GameManager.Reset();
		public void Resume() => GameManager.Continue();
		public void Pause() => GameManager.Pause();
		public void Exit() => GameManager.ExitApp();
	}
}
