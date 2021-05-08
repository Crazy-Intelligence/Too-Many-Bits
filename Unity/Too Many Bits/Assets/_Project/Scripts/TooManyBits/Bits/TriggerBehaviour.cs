using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "Collector", menuName = "TooManyBits/Behaviour/Collector")]
	public class TriggerBehaviour : ScriptableObject
	{
		[SerializeField] private int scoreMultiplier;
		[SerializeField] private int moneyMultiplier;

		[Header("Behaviour")]
		[SerializeField] private Behaviour behaviour;

		public void Invoke(Bit bit)
		{
			var config = bit.Config;

			config.ChangeScore(scoreMultiplier);
			config.ChangeMoney(moneyMultiplier);

			switch (behaviour)
			{
				case Behaviour.deleteImmediatly:
					bit.DeleteImmediatly();
					break;
				case Behaviour.destroy:
					bit.Destroy();
					break;
				case Behaviour.shrink:
					bit.Shrink();
					break;
				case Behaviour.grow:
					bit.Grow();
					break;
			}
		}

		private enum Behaviour
		{
			deleteImmediatly,
			destroy,
			shrink,
			grow
		}
	}
}
