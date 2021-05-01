using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public abstract class Wave : ScriptableObject
	{
		[ContextMenu("Apply Next")]
		public abstract void ApplyNextWave();

		[ContextMenu("Apply Previous")]
		public abstract void ApplyPreviousWave();
	}
}
