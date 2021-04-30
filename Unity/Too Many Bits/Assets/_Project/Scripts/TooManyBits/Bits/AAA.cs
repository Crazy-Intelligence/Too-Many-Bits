using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public abstract class AAA : ScriptableObject
	{
		[ContextMenu("Apply Next")]
		public abstract void ApplyNextWave();

		[ContextMenu("Apply Previous")]
		public abstract void ApplyPreviousWave();
	}
}
