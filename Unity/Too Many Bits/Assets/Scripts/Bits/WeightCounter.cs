namespace CrazyIntelligence.Bits
{
	public static class WeightCounter
	{
		public static int Weight { get; private set; }

		public static void Add(int amount)
		{
			Weight += amount;
		}

		public static void Remove(int amount)
		{
			Weight -= amount;
		}
	}
}
