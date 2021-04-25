using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.Bits
{
	public class GameManagerBehaviour : MonoBehaviour
	{
		[SerializeField] private GameObject envoirmentPrefab;
		[SerializeField] [Range(500, 1500)] private int weightUntilGameOver;
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

		private void Start()
		{
			GameManager.StartApp();
		}

		private void Update()
		{
			if (GameManager.CheckGameOver())
			{
				OnGameOverEvent?.Invoke();
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

			Cursor.visible = !GameManager.IsPlaying;
		}

		private void OnReset()
		{
			Destroy(_currentEnvoirment);
			Instantiate(envoirmentPrefab);
		}
	}
}
