using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class MoneyCounterBehaviour : MonoBehaviour
	{
		public void Add(int amount)
		{
			MoneyCounter.Add(amount);
		}

		public void Remove(int amount)
		{
			MoneyCounter.Remove(amount);
		}
	}
}
