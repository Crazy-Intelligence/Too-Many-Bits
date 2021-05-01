using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "SimpleWaves", menuName = "TooManyBits/Wave/SimpleCollection")]
	public class SimpleWaveCollection : Wave
	{
		[SerializeField] private BasicWave[] waves;

		int _currentIndex;

		public override void ApplyBase()
		{
			waves[0].Apply();
		}
		public override void ApplyNext()
		{
			if (_currentIndex >= waves.Length) return;

			waves[_currentIndex].Apply();
			_currentIndex++;
		}
		public override void ApplyPrevious()
		{
			if (_currentIndex <= 0) return;

			_currentIndex--;
			waves[_currentIndex].Apply();
		}
	}
}
