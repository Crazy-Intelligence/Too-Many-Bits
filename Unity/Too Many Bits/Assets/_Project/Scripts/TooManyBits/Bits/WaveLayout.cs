using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public abstract class WaveLayout : ScriptableObject
	{
		public abstract void Apply(int wave);
		public abstract void ApplyDefaultWave();
		public abstract void ApplyNextWave();
	}
}
