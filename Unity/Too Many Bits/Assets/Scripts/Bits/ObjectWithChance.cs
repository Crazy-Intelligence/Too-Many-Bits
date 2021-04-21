using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[System.Serializable]
	public class ObjectWithChance<T>
	{
		public T Object;
		public int Weight;
	}
}
