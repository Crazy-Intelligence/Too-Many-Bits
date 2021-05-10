using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Waves
{
	[CreateAssetMenu(fileName = "Layout", menuName = "TooManyBits/Waves/Layout")]
	public class WaveLayout : ScriptableObject
	{
		public Wave Disabled;
		[SerializeField] private Wave[] Waves;

		public int WaveCount => Waves.Length;

		public void Apply(int index, out float duration)
		{
			if (index >= Waves.Length)
			{
				duration = 0f;
				return;
			}

			Waves[index].Apply();
			duration = Waves[index].Duration;
		}
	}
}
