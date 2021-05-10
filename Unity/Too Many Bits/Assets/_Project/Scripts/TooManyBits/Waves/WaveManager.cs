using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	public class WaveManager : MonoBehaviour
	{
		[SerializeField] private WaveLayout layout;

		private int _currentIndex;

		private void Start()
		{
			Disable();
		}

		public void Disable()
		{
			layout.Disabled.Apply();
		}

		public void BaseWave()
		{
			_currentIndex = 1;
			layout.Waves[0].Apply();
		}

		public void NextWave()
		{
			if (_currentIndex >= layout.Waves.Length) return;

			layout.Waves[_currentIndex].Apply();

			_currentIndex++;
		}
	}
}
