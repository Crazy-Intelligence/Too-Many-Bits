using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "BitConfig", menuName = "TooManyBits/Bits/Config")]
	public class BitConfig : ScriptableObject
	{
		[Header("Shared")]
		[SerializeField] private SharedBitConfig sharedConfig;

		[Header("Visuals")]
		public SpriteCollection Sprites;
		public Color NormalColor;

		[Header("Transform Info")]
		public float NormalScale;
		[Space]
		public Vector2 ColliderOffset;
		public Vector2 ColliderSize;

		[Header("Values")]
		[SerializeField] private int scoreValue;
		[SerializeField] private int moneyValue;
		[SerializeField] private int weightValue;

		public float DestroyDuration => sharedConfig.DestroyDuration;
		public float ScaleDuration => sharedConfig.ScaleDuration;
		
		public Color DestroyedColor => sharedConfig.DestroyedColor;
		public float SmallScale => sharedConfig.SmallScale;


		public void ChangeScore(int multiplier) => sharedConfig.ChangeScore(scoreValue * multiplier);
		public void ChangeMoney(int multiplier) => sharedConfig.ChangeMoney(moneyValue * multiplier);

		public void AddWeight() => sharedConfig.ChangeWeight(weightValue);
		public void RemoveWeight() => sharedConfig.ChangeWeight(-weightValue);
	}
}
