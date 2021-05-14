using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CrazyIntelligence.TooManyBits.UI
{
	public class WeightDisplay : MonoBehaviour
	{
		[SerializeField] private Counter weight;
		[SerializeField] private int[] triggers = new int[4];
		[Header("Display")]
		[SerializeField] private Image image;
		[SerializeField] private Sprite empty;
		[SerializeField] private Sprite[] fillStates = new Sprite[4];
		[SerializeField] private UnityEvent OnFillStateRise;
		[SerializeField] private UnityEvent OnFillStateFall;
		[SerializeField] private UnityEvent OnFillStateCritical;

		private int _lastIndex;
		private bool disabled;

		private void Start()
		{
			image.sprite = empty;
		}
		private void Update()
		{
			if (disabled) return;

			int i = GetCurrentIndex();

			ChangeSprite(i);

			if (i == _lastIndex) return;

			InvokeEvents(i);
		}

		private void InvokeEvents(int i)
		{
			if (i > _lastIndex)
			{
				OnFillStateRise?.Invoke();

				if (i >= 4)
				{
					OnFillStateCritical?.Invoke();
				}
			}
			if (i < _lastIndex)
			{
				OnFillStateFall?.Invoke();
			}
		}

		private void ChangeSprite(int i)
		{
			if (i == -1)
			{
				image.sprite = empty;
			}
			else
			{
				image.sprite = fillStates[i];
			}
		}

		public void Disable() => disabled = true;
		public void Enable() => disabled = false;

		private int GetCurrentIndex()
		{
			for (int i = 4 - 1; i >= 0; i--)
			{
				int trigger = triggers[i];
				if (weight.Value >= trigger)
				{
					return i;
				}
			}

			return -1;
		}
	}
}
