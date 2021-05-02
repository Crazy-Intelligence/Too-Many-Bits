using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class Bit : MonoBehaviour
	{
		public BitConfig Config;

		[SerializeField] private Counter weight;

		private CapsuleCollider2D _collider;
		private SpriteRenderer _spriteRenderer;
		private SpriterChanger _spriteChanger;

		private Vector3 deltaScale;
		private bool _scaling;
		
		private void Awake()
		{
			GetReferences();
		}

		private void OnEnable()
		{
			SetupObject();

			GameManager.OnReset += DestroyThisObject;
			weight.Add(Config.WeightValue);
		}
		private void OnDisable()
		{
			GameManager.OnReset -= DestroyThisObject;
			weight.Remove(Config.WeightValue);
		}

		private void Update()
		{
			if (_scaling)
			{
				Scale();
			}

			ChangeColor();
		}

		public void Destroy()
		{
			
		}

		public void Shrink()
		{
			deltaScale = -Config.DeltaScale;
			_scaling = true;
		}
		public void Grow()
		{
			deltaScale = Config.DeltaScale;
			_scaling = true;
		}

		private void ChangeColor()
		{

		}

		private void Scale()
		{
			var currentScale = transform.localScale;

			if (Config.IsOutOfBounds(currentScale, out var clamped))
			{
				transform.localScale = clamped;
				_scaling = false;
				return;
			}

			var newScale = currentScale + (deltaScale * (Time.deltaTime / Config.ScaleDuration));

			transform.localScale = newScale;
		}

		private void GetReferences()
		{
			_collider = GetComponent<CapsuleCollider2D>();
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_spriteChanger = GetComponent<SpriterChanger>();
		}
		private void SetupObject()
		{
			transform.localScale = new Vector3(Config.Scale, Config.Scale, 1f);

			_collider.offset = Config.ColliderOffset;
			_collider.size = Config.ColliderSize;

			_spriteRenderer.color = Config.Color;
			
			_spriteChanger.spriteCollection = Config.Sprites;
		}

		private void DestroyThisObject()
		{
			Destroy(gameObject);
		}

		[ContextMenu("Setup")]
		private void InspectorSetup()
		{
			GetReferences();
			SetupObject();
		}
	}
}
