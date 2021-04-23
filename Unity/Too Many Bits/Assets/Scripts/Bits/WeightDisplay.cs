using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class WeightDisplay : MonoBehaviour
	{
		[Header("Trigger")]
		[SerializeField] private int[] triggers = new int[4];
		[Header("Display")]
		[SerializeField] private Transform mask;
		[SerializeField] private Vector2[] steps = new Vector2[4];

		private Vector3 _defaultPos;

		private void Start()
		{
			_defaultPos = mask.localPosition;
		}
		private void Update()
		{
			int i = GetCurrentIndex();

			if (i == -1)
			{
				mask.localPosition = _defaultPos;
			}
			else
			{
				mask.localPosition = new Vector3(steps[i].x, steps[i].y);
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
