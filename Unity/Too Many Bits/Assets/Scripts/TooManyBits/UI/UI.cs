using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	public class UI : MonoBehaviour
	{
		public void Play() => GameManager.Start();
		public void Restart() => GameManager.Reset();
		public void Resume() => GameManager.Continue();
		public void Pause() => GameManager.Pause();
		public void Exit() => GameManager.ExitApp();
	}
}
