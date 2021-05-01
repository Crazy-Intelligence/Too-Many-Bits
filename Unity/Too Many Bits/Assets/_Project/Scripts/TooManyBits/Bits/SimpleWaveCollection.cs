using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "SimpleWaves", menuName = "TooManyBits/Wave/SimpleCollection")]
	public class SimpleWaveCollection : Wave
	{
		[SerializeField] private SimpleWave[] waves;

		int _currentIndex;

		public override void ApplyNextWave()
		{
			if (_currentIndex >= waves.Length) return;

			waves[_currentIndex].Apply();
			_currentIndex++;
		}

		public override void ApplyPreviousWave()
		{
			if (_currentIndex <= 0) return;

			_currentIndex--;
			waves[_currentIndex].Apply();
		}
	}
}
