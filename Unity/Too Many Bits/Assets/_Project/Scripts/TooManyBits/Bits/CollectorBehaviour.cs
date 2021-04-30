using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "Collector", menuName = "TooManyBits/Behaviour/Collector")]
	public class CollectorBehaviour : ScriptableObject
	{
		[Header("Score")]
		[SerializeField] private Counter score;
		[SerializeField] private int scoreMultiplier;

		[Header("Money")]
		[SerializeField] private Counter money;
		[SerializeField] private int moneyMultiplier;

		[Header("Behaviour")]
		[SerializeField] private Behaviour behaviour;

		public void Invoke(Bit bit)
		{
			var info = bit.Config;

			score.Add(info.ScoreValue * scoreMultiplier);
			money.Add(info.MoneyValue * moneyMultiplier);

			switch (behaviour)
			{
				case Behaviour.deleteImmediatly:
					Destroy(bit.gameObject);
					break;
				case Behaviour.destroy:
					bit.Destroy();
					break;
				case Behaviour.shrink:
					bit.Shrink();
					break;
			}
		}

		private enum Behaviour
		{
			deleteImmediatly,
			destroy,
			shrink
		}
	}
}
