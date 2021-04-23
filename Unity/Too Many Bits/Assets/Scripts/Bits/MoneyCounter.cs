using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public static class MoneyCounter
	{
		public static int Money { get; private set; }

		public static void Add(int amount)
		{
			Money += amount;
		}
		public static void Remove(int amount)
		{
			Money -= amount;

			if (Money < 0)
			{
				Money = 0;
			}
		}
	}
}
