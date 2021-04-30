using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "Waves", menuName = "TooManyBits/Wave/Layout")]
	public class WaveLayout : ScriptableObject
	{
		[SerializeField] private Wave[] waves;

		int _currentIndex;

		public void ApplyNextWave()
		{
			if (_currentIndex >= waves.Length) return;

			waves[_currentIndex].Apply();
			_currentIndex++;
		}

		public void ApplyPreviousWave()
		{
			if (_currentIndex <= 0) return;

			_currentIndex--;
			waves[_currentIndex].Apply();
		}
	}
}
