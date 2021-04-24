using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class UI : MonoBehaviour
	{
		public void Play() => GameManager.Start();
		public void Restart() => GameManager.Restart();
		public void Resume() => GameManager.Continue();
		public void Pause() => GameManager.Pause();
		public void Exit() => GameManager.ExitApp();
	}
}
