using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	[CreateAssetMenu(fileName = "Counter", menuName = "TooManyBits/Counter")]
	public class Counter : ScriptableObject
	{
		public int Count;
		[SerializeField] private bool CanBeNegative;

		public void Add(int amount) => Count += amount;
		public void Remove(int amount)
		{
			Count -= amount;

			if (Count < 0 && !CanBeNegative)
			{
				Reset();
			}
		}

		public void Reset()
		{
			Count = 0;
		}
	}
}
