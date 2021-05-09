using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	public abstract class Wave : ScriptableObject
	{
		public abstract void ApplyBase();
		public abstract void ApplyNext();
	}
}
