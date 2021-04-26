using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[System.Serializable]
	public class SpawnerInfo
	{
		public Vector3 Position;
		public bool Mirrored;

		public SpawnerConfig Config;
		public BitCollection Objects;
	}
}
