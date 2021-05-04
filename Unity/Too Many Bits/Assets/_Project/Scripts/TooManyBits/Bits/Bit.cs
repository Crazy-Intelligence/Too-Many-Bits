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

		private Timer _timer;

		private Vector3 _targetScale;
		private bool _scaling;

		private bool _changingColor;

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
			if (_changingColor)
			{
				ChangeColor();
				_timer.Tick(Time.deltaTime);
			}
		}

		public void DeleteImmediatly()
		{
			DestroyThisObject();
		}
		public void Destroy()
		{
			_changingColor = true;
			_timer = new Timer(Config.DestroyDuration);
			_timer.OnTimerEnd += DestroyThisObject;
		}
		public void Shrink()
		{
			_targetScale = Vector3.one * Config.SmallScale;
			_scaling = true;
		}
		public void Grow()
		{
			_targetScale = Vector3.one * Config.Scale;
			_scaling = true;
		}

		private void ChangeColor()
		{
			_spriteRenderer.color = Color.Lerp(_spriteRenderer.color, Config.DestroyColor, Time.deltaTime / Config.DestroyDuration);
			if (_spriteRenderer.color == Config.DestroyColor)
			{
				_changingColor = false;
			}
		}

		private void Scale()
		{
			transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, Time.deltaTime / Config.ScaleDuration);
			if (transform.localScale == _targetScale)
			{
				_scaling = false;
			}
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
			ObjectPool.Despawn(gameObject);
		}

		[ContextMenu("Setup")]
		private void InspectorSetup()
		{
			GetReferences();
			SetupObject();
		}
	}
}
