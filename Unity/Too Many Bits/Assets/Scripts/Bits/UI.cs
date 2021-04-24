using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(Animator))]
	public class UI : MonoBehaviour
	{
		[SerializeField] private GameObject StartMenu;
		[SerializeField] private GameObject PauseMenu;

		private Animator _animator;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}
		private void OnEnable()
		{
			GameManager.OnStart += OnStart;
			GameManager.OnGameOver += OnGameOver;
		}
		private void OnDisable()
		{
			GameManager.OnStart -= OnStart;
			GameManager.OnGameOver -= OnGameOver;
		}
		private void Start()
		{
			StartMenu.SetActive(false);
			PauseMenu.SetActive(false);
		}

		private void Update()
		{
			_animator.SetBool("IsPlaying", GameManager.IsPlaying);
			_animator.SetBool("IsPaused", GameManager.IsPaused);
		}

		public void Play() => GameManager.Start();
		public void Restart() => GameManager.Restart();
		public void Resume() => GameManager.Continue();
		public void Pause() => GameManager.Pause();
		public void Exit() => GameManager.ExitApp();

		private void OnStart()
		{
			_animator.SetTrigger("StartPlaying");
			_animator.SetBool("ShopUnlocked", true);
		}
		private void OnGameOver()
		{
			_animator.SetTrigger("GameOver");
		}
	}
}
