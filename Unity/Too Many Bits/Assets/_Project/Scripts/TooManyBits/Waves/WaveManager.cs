using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	public class WaveManager : MonoBehaviour
	{
		[SerializeField] private Wave wave;
		[SerializeField] private Wave disabled;

		private void Start()
		{
			DisableWave();
		}

		public void DisableWave() => disabled.ApplyBase();

		public void BaseWave() => wave.ApplyBase();

		public void NextWave() => wave.ApplyNext();
	}
}
