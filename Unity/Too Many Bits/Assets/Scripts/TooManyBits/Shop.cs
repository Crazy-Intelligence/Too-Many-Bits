using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CrazyIntelligence.TooManyBits
{
	public class Shop : MonoBehaviour
	{
		[SerializeField] private Counter money;
		[SerializeField] private Text priceTag;
		[SerializeField] private int price;
		[SerializeField] private UnityEvent OnBuy;

		private void Start()
		{
			priceTag.text = $"$ {price}";
		}

		public void TryBuy()
		{
			if (money.Count >= price)
			{
				money.Remove(price);

				OnBuy?.Invoke();
			}
		}
	}
}
