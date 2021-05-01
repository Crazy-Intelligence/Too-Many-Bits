using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class WaveManager : MonoBehaviour
	{
		[SerializeField] private WaveLayout waveLayout;
		
		private void Start()
		{
			waveLayout.ApplyNextWave();
		}

		public void NextWave() => waveLayout.ApplyNextWave();
		public void PreviousWave() => waveLayout.ApplyPreviousWave();
	}
}
