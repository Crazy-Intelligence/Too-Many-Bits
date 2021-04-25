using UnityEngine;
using UnityEngine.UI;

namespace CrazyIntelligence.Bits
{
	public class WeightDisplay : MonoBehaviour
	{
		[Header("Trigger")]
		[SerializeField] private int[] triggers = new int[4];
		[Header("Display")]
		[SerializeField] private Image image;
		[SerializeField] private Sprite empty;
		[SerializeField] private Sprite[] fillStates = new Sprite[4];

		private bool disabled;

		private void Start()
		{
			image.sprite = empty;
		}
		private void OnEnable()
		{
			GameManager.OnReset += Enable;
			GameManager.OnGameOver += Disable;
		}
		private void OnDisable()
		{
			GameManager.OnReset -= Enable;
			GameManager.OnGameOver -= Disable;
		}

		private void Update()
		{
			if (disabled) return;

			int i = GetCurrentIndex();

			if (i == -1)
			{
				image.sprite = empty;
			}
			else
			{
				image.sprite = fillStates[i];
			}
		}

		private void Disable() => disabled = true;
		private void Enable() => disabled = false;

		private int GetCurrentIndex()
		{
			for (int i = 4 - 1; i >= 0; i--)
			{
				int trigger = triggers[i];
				if (Counter.Weight >= trigger)
				{
					return i;
				}
			}

			return -1;
		}
	}
}
