using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(SpriterChanger), typeof(Sticky))]
	public class Bit : MonoBehaviour
	{
		public BitData Data;

		private SpriteRenderer _spriteRenderer;
		private CapsuleCollider2D _collider;
		private SpriterChanger _spriteChanger;
		private Sticky _sticky;

		private void Awake()
		{
			GetReferences();
		}

		private void OnEnable()
		{
			SetupObject();

			Counter.AddWeight(Data.Weight);
		}
		private void OnDisable()
		{
			Counter.RemoveWeight(Data.Weight);
		}

		private void SetupObject()
		{
			transform.localScale = new Vector3(Data.Scale, Data.Scale, 1f);

			_spriteRenderer.color = Data.Color;
			_spriteRenderer.sortingLayerName = "Bits";

			_collider.offset = Data.ColliderOffset;
			_collider.size = Data.ColliderSize;

			_spriteChanger.spriteCollection = Data.SpriteCollection;

			_sticky.Active = Data.isSticky;
		}

		private void GetReferences()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_collider = GetComponent<CapsuleCollider2D>();
			_spriteChanger = GetComponent<SpriterChanger>();
			_sticky = GetComponent<Sticky>();
		}

		[ContextMenu("Setup")]
		private void InspectorSetup()
		{
			GetReferences();
			SetupObject();
		}
	}
}
