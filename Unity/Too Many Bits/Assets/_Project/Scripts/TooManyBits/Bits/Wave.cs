using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public abstract class Wave : ScriptableObject
	{
		public abstract void ApplyBase();

		public abstract void ApplyNext();

		public abstract void ApplyPrevious();
	}
}
