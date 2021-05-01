using System;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	[CreateAssetMenu(fileName = "Item", menuName = "TooManyBits/Item")]
	public class Item : ScriptableObject
	{
		public Sprite Icon;
		public int Price;

		public event Action OnBought;
		public void Buy()
		{
			OnBought?.Invoke();
		}
	}
}
