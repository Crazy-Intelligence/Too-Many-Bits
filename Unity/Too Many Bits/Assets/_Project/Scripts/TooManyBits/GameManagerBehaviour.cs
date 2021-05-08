using UnityEngine;
using UnityEngine.SceneManagement;

namespace CrazyIntelligence.TooManyBits
{
	public class GameManagerBehaviour : MonoBehaviour
	{
		[SerializeField] private Counter gameOverTrigger;
		[SerializeField] [Range(500, 1500)] private int countUntilGameOver;

		private void Awake()
		{
			SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
		}
		private void Start()
		{
			GameManager.StartApp();
		}

		private void Update()
		{
			if (gameOverTrigger.Count >= countUntilGameOver)
			{
				GameManager.DoGameOver();
			}
		}
	}
}
