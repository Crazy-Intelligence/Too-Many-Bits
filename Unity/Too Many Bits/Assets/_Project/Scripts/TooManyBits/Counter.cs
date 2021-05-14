using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	[CreateAssetMenu(fileName = "Counter", menuName = "TooManyBits/Counter")]
	public class Counter : ScriptableObject
	{
		public int Value;
		[SerializeField] private bool CanBeNegative;

		public void Add(int amount) => Value += amount;
		public void Remove(int amount)
		{
			Value -= amount;

			if (Value < 0 && !CanBeNegative)
			{
				Reset();
			}
		}

		public void Reset()
		{
			Value = 0;
		}
	}
}
