namespace CrazyIntelligence.Bits
{
	public static class ScoreCounter
	{
		public static int Score { get; private set; }

		public static void Add(int amount)
		{
			Score += amount;
		}

		public static void Remove(int amount)
		{
			Score -= amount;
		}
	}
}
