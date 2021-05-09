using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[CreateAssetMenu(fileName = "SimpleWaves", menuName = "TooManyBits/Wave/Collection/Simple")]
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
	}
}
