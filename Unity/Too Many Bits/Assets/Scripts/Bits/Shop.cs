using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CrazyIntelligence.Bits
{
	public class Shop : MonoBehaviour
	{
		[SerializeField] private Text priceTag;
		[SerializeField] private int price;
		[SerializeField] private UnityEvent OnBuy;

		private void Start()
		{
			priceTag.text = $"$ {price}";
		}

		public void TryBuy()
		{
			if (MoneyCounter.Money >= price)
			{
				MoneyCounter.Remove(price);

				OnBuy?.Invoke();
			}
		}
	}
}
