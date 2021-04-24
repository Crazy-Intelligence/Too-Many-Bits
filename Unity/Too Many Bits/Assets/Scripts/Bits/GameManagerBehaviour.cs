using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.Bits
{
	public class GameManagerBehaviour : MonoBehaviour
	{
		[SerializeField] private GameObject envoirmentPrefab;
		[SerializeField] private UnityEvent OnResetEvent;
		[SerializeField] private int weightUntilGameOver;
		[SerializeField] private UnityEvent OnGameOverEvent;

		private GameObject _currentEnvoirment;

		private void Awake()
		{
			_currentEnvoirment = FindObjectOfType<Envoirment>().gameObject;

			GameManager.WeightUntilGameOver = weightUntilGameOver;
		}

		private void OnEnable()
		{
			GameManager.OnReset += OnReset;
		}
		private void OnDisable()
		{
			GameManager.OnReset -= OnReset;
		}

		private void Update()
		{
			if (GameManager.CheckGameOver())
			{
				OnGameOverEvent?.Invoke();
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				GameManager.Pause();
			}

			Cursor.visible = !GameManager.IsPlaying;
		}

		private void OnReset()
		{
			OnResetEvent?.Invoke();

			Destroy(_currentEnvoirment);
			Instantiate(envoirmentPrefab);
		}
	}
}
