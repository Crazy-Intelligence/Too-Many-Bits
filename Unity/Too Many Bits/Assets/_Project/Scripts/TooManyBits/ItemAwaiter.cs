using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits
{
	public class ItemAwaiter : MonoBehaviour
	{
		[SerializeField] private Item item;
		[SerializeField] private UnityEvent OnItemBought;

		private void OnEnable()
		{
			item.OnBought += OnBought;
		}
		private void OnDisable()
		{
			item.OnBought -= OnBought;
		}

		private void OnBought()
		{
			OnItemBought?.Invoke();
		}
	}
}
