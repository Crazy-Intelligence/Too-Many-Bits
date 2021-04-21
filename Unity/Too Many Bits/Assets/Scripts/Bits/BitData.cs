using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[CreateAssetMenu(fileName = "Bit", menuName = "Bits/BitData")]
	public class BitData : ScriptableObject
	{
		public SpriteCollection SpriteCollection;
		public Color Color;
		[Space]
		public float Scale;
		[Space]
		public Vector2 ColliderOffset;
		public Vector2 ColliderSize;
		[Space]
		public int BaseValue;
	}
}
