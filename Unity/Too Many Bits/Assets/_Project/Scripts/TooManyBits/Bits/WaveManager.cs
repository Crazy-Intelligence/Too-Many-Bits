using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class WaveManager : MonoBehaviour
	{
		[SerializeField] private Wave wave;
		
		private void Start()
		{
			wave.ApplyNextWave();
		}

		public void NextWave() => wave.ApplyNextWave();
		public void PreviousWave() => wave.ApplyPreviousWave();
	}
}
