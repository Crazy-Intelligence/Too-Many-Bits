using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[System.Serializable]
	public class DynamicWaveInfo
	{
		[SerializeField] private Wave wave;
		public int MaxLevelUpCount;

		private int _remainingLevelUps;
		public int RemainingLevelUps { get => _remainingLevelUps; }

		public void ApplyBase()
		{
			_remainingLevelUps = MaxLevelUpCount;
			wave.ApplyBase();
		}

		public void ApplyNext()
		{
			_remainingLevelUps--;
			wave.ApplyNext();
		}
	}
}
