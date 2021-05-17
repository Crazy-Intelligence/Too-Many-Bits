using UnityEngine;
using UnityEngine.SceneManagement;

namespace CrazyIntelligence.TooManyBits
{
	public class GameManagerBehaviour : MonoBehaviour
	{
		[SerializeField] private Counter weight;
		[Range(500, 1500)] public int WeightUntilGameOver;

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
			if (weight.Value >= WeightUntilGameOver)
			{
				GameManager.DoGameOver();
			}
		}
	}
}
