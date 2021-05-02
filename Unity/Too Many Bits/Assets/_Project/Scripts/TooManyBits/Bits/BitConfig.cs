using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	[CreateAssetMenu(fileName = "BitConfig", menuName = "TooManyBits/Bits/Config")]
	public class BitConfig : ScriptableObject
	{
		[Header("Visuals")]
		public SpriteCollection Sprites;
		public Color Color;
		public Color DestroyColler;

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

		public Vector3 ScaleVector => Vector3.one * Scale;
		public Vector3 SmallScaleVector => Vector3.one * SmallScale;
		public Vector3 DeltaScale => ScaleVector - SmallScaleVector;
		
		public bool IsOutOfBounds(Vector3 scale, out Vector3 clamped)
		{
			if (scale.x > Scale)
			{
				clamped = ScaleVector;
				return true;
			}
			if (scale.x < SmallScale)
			{
				clamped = SmallScaleVector;
				return true;
			}

			clamped = scale;
			return false;
		}
	}
}
