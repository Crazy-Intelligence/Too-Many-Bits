namespace CrazyIntelligence.Bits
{
	public static class Counter
	{
		public static int Weight { get; private set; }
		public static int Score { get; private set; }
		public static int Money { get; private set; }


		public static void AddWeight(int amount) => Weight += amount;
		public static void AddScore(int amount) => Score += amount;
		public static void AddMoney(int amount) => Money += amount;

		public static void RemoveWeight(int amount) => Weight -= amount;
		public static void RemoveScore(int amount) => Score -= amount;
		public static void RemoveMoney(int amount)
		{
			Money -= amount;
			if (Money < 0)
			{
				Money = 0;
			}
		}

		public static void ResetWeight() => Weight = 0;
		public static void ResetScore() => Score = 0;
		public static void ResetMoney() => Money = 0;

		public static void ResetAll()
		{
			ResetWeight();
			ResetScore();
			ResetMoney();
		}
	}
}
