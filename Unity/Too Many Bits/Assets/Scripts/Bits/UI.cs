using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class UI : MonoBehaviour
	{
		[SerializeField] private GameObject StartMenu;
		[SerializeField] private GameObject PauseMenu;

		private float _timeScale;

		private void Awake()
		{
			ShowStartMenu();
		}
		private void OnEnable()
		{
			GameManager.OnGamePause += Pause;
		}
		private void OnDisable()
		{
			GameManager.OnGamePause -= Pause;
		}

		public void Play()
		{
			GameManager.StartGame();
			HideStartMenu();
		}
		public void Restart()
		{
			Play();
		}
		public void Resume()
		{
			GameManager.ContinueGame();
			HidePauseMenu();
		}
		public void Pause()
		{
			ShowPauseMenu();
		}

		public void Exit()
		{
			GameManager.ExitGame();
		}

		private void ShowStartMenu()
		{
			StartMenu.SetActive(true);
		}
		private void HideStartMenu()
		{
			StartMenu.SetActive(false);
		}
		private void ShowPauseMenu()
		{
			PauseMenu.SetActive(true);
		}
		private void HidePauseMenu()
		{
			PauseMenu.SetActive(false);
		}
	}
}
