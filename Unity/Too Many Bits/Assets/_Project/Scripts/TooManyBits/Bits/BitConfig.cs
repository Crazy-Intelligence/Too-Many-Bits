using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "BitConfig", menuName = "TooManyBits/Bits/Config")]
	public class BitConfig : ScriptableObject
	{
		[Header("Visuals")]
		public SpriteCollection Sprites;
		public Color Color;
		public Color DestroyColor;

		[Header("Animations")]
		public float ScaleDuration;
		public float DestroyDuration;

		[Header("Size")]
		public float Scale;
		public float SmallScale;

		[Header("Collider")]
		public Vector2 ColliderOffset;
		public Vector2 ColliderSize;

		[Header("Value")]
		public int ScoreValue;
		public int MoneyValue;
		public int WeightValue;
	}
}
