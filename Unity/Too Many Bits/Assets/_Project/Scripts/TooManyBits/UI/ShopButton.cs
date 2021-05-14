using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace CrazyIntelligence.TooManyBits.UI
{
	public class ShopButton : MonoBehaviour
	{
		[SerializeField] private TMP_Text priceTag;
		[SerializeField] private Image image;
		[Space]
		[SerializeField] private Counter money;
		[SerializeField] private Item item;

		private void Start()
		{
			priceTag.text = $"$ {item.Price}";
			image.sprite = item.Icon;
		}

		public void TryBuy()
		{
			if (money.Value < item.Price) return;

			money.Remove(item.Price);

			item.Buy();
		}
	}
}
