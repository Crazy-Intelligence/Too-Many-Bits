using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "StaticWaves", menuName = "TooManyBits/Waves/Static")]
	public class StaticWaveLayout : WaveLayout
	{
		[SerializeField] private List<Wave> Waves = new List<Wave>();

		private int _currentWave = 0;

		public override void Apply(int wave)
		{
			if (!ValidateWaveIndex(wave)) return;

			Waves[wave].Apply();
		}

		public override void ApplyDefaultWave()
		{
			if (Waves.Count == 0) return;

			Waves[0].Apply();
		}

		public override void ApplyNextWave()
		{
			if (Waves.Count == 0) return;

			_currentWave++;

			Waves[_currentWave].Apply();
		}

		private bool ValidateWaveIndex(int index)
		{
			if (index < 0) return false;
			if (index > Waves.Count - 1) return false;
			return true;
		}
	}
}
