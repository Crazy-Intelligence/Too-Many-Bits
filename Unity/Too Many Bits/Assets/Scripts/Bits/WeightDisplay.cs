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

		private void Start()
		{
			image.sprite = empty;
		}
		private void Update()
		{
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

		private int GetCurrentIndex()
		{
			for (int i = 4 - 1; i >= 0; i--)
			{
				int trigger = triggers[i];
				if (WeightCounter.Weight >= trigger)
				{
					return i;
				}
			}

			return -1;
		}
	}
}
