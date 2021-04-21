using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(SpriterChanger))]
	public class Bit : MonoBehaviour
	{
		public BitData Data;

		private SpriteRenderer _spriteRenderer;
		private CapsuleCollider2D _collider;
		private SpriterChanger _spriteChanger;

		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_spriteChanger = GetComponent<SpriterChanger>();
			_collider = GetComponent<CapsuleCollider2D>();
		}
		private void OnEnable()
		{
			transform.localScale = new Vector3(Data.Scale, Data.Scale, 1f);

			_spriteRenderer.color = Data.Color;
			_spriteRenderer.sortingLayerName = "Bits";

			_spriteChanger.spriteCollection = Data.SpriteCollection;
			
			_collider.offset = Data.ColliderOffset;
			_collider.size = Data.ColliderSize;
		}
	}
}
