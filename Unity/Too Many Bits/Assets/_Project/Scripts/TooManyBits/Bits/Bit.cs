using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class Bit : MonoBehaviour
	{
		public BitConfig Config;

		[SerializeField] private Counter weight;

		private CapsuleCollider2D _collider;
		private AudioSource _audioSource;
		private SpriteRenderer _spriteRenderer;
		private SpriterChanger _spriteChanger;

		private Timer _timer;

		private Vector3 _targetScale;
		private bool _scaling;

		private bool _destroying;

		private void Awake()
		{
			GetReferences();
		}

		private void OnEnable()
		{
			GameManager.OnReset += Despawn;
		}
		private void OnDisable()
		{
			GameManager.OnReset -= Despawn;
		}

		private void Update()
		{
			if (_scaling)
			{
				Scale();
			}
			if (_destroying)
			{
				ChangeColor();
				_timer.Tick(Time.deltaTime);
			}
		}

		public void Enable()
		{
			weight.Add(Config.WeightValue);

			SetupObject();
		}

		public void DeleteImmediatly()
		{
			Despawn();
		}

		public void Destroy()
		{
			_destroying = true;
			_collider.enabled = false;
			_timer = new Timer(Config.DestroyDuration);
			_timer.OnTimerEnd += Despawn;

			Config.OnDestroyClip.Play(_audioSource);
		}
		public void Shrink()
		{
			_targetScale = Vector3.one * Config.SmallScale;
			gameObject.layer = LayerMask.NameToLayer("SmallBits");
			_scaling = true;

			Config.OnCollectClip.Play(_audioSource);
		}
		public void Grow()
		{
			_targetScale = Vector3.one * Config.Scale;
			gameObject.layer = LayerMask.NameToLayer("Bits");
			_scaling = true;
		}

		private void ChangeColor()
		{
			_spriteRenderer.color = Color.Lerp(_spriteRenderer.color, Config.DestroyColor, Time.deltaTime / Config.DestroyDuration);
			if (_spriteRenderer.color == Config.DestroyColor)
			{
				_destroying = false;
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
			_audioSource = GetComponent<AudioSource>();
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_spriteChanger = GetComponent<SpriterChanger>();
		}
		private void SetupObject()
		{
			transform.localScale = new Vector3(Config.Scale, Config.Scale, 1f);

			_collider.enabled = true;
			_collider.offset = Config.ColliderOffset;
			_collider.size = Config.ColliderSize;

			_spriteRenderer.color = Config.Color;
			
			_spriteChanger.spriteCollection = Config.Sprites;

			gameObject.layer = LayerMask.NameToLayer("Bits");

			_scaling = false;
			_destroying = false;
		}

		private void Despawn()
		{
			weight.Remove(Config.WeightValue);
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
