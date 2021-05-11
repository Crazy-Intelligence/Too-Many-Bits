using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "Bits", menuName = "TooManyBits/Bits/SharedConfig")]
	public class SharedBitConfig : ScriptableObject
	{
		[Header("Counter")]
		[SerializeField] private Counter score;
		[SerializeField] private Counter money;
		[SerializeField] private Counter weight;
		
		[Header("Animations")]
		public float ScaleDuration;
		public float DestroyDuration;
		[Space]
		public Color DestroyedColor;

		[Header("Physics")]
		public float SmallScale;
		public float SmallMass;

		public void ChangeScore(int amount) => score.Add(amount);
		public void ChangeMoney(int amount) => money.Add(amount);
		public void ChangeWeight(int amount) => weight.Add(amount);
	}
}
