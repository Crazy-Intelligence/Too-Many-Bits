using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[CreateAssetMenu(fileName = "DynamicWaves", menuName = "TooManyBits/Wave/Collection/Dynamic")]
	public class DynamicWavecollection : Wave
	{
		[SerializeField] private DynamicWaveInfo[] waves;

		private int _current;

		public override void ApplyBase()
		{
			_current = 0;
			waves[_current].wave.ApplyBase();
		}

		public override void ApplyNext()
		{
			if (waves[_current].RemainingLevelUps <= 0)
			{
				if (_current < waves.Length - 1)
				{
					_current++;
				}
			}
			waves[_current].ApplyNext();
		}
	}
}
