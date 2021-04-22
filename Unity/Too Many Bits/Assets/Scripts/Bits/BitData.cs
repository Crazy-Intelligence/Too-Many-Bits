using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[CreateAssetMenu(fileName = "Bit", menuName = "Bits/BitData")]
	public class BitData : ScriptableObject
	{
		[Header("Visuals")]
		public SpriteCollection SpriteCollection;
		public Color Color;
		[Header("Size")]
		public float Scale;
		public int Weight;
		[Header("Hitbox")]
		public Vector2 ColliderOffset;
		public Vector2 ColliderSize;
		[Header("Score")]
		public int BaseValue;
		[Header("Attributes")]
		public bool isSticky;
	}
}
