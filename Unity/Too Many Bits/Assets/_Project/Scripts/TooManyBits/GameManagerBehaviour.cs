using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits
{
	public class GameManagerBehaviour : MonoBehaviour
	{
		[SerializeField] private Counter gameOverTrigger;
		[SerializeField] [Range(500, 1500)] private int countUntilGameOver;

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

			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = !GameManager.IsPlaying;
		}
	}
}
