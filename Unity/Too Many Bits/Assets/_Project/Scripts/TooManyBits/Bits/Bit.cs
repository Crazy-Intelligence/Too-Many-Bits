using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class Bit : MonoBehaviour
	{
		public BitConfig Config;
		[SerializeField] private UnityEvent OnGrowEvent;
		[SerializeField] private UnityEvent OnShrinkEvent;
		[SerializeField] private UnityEvent OnDestroyEvent;
		
		private CapsuleCollider2D _collider;
		private SpriteRenderer _spriteRenderer;
		private SpriterChanger _spriteChanger;

		private void Awake()
		{
			GetReferences();
		}
		
		private void OnEnable()
		{
			Config.AddWeight();
			SetupObject();
		}
		private void OnDisable()
		{
			StopAllCoroutines();
		}

		public void DeleteImmediatly()
		{
			StartCoroutine(Despawn(0f));
		}

		public void Destroy()
		{
			StartCoroutine(ChangeColor(Config.DestroyedColor, Config.DestroyDuration));

			_collider.enabled = false;

			StartCoroutine(Despawn(Config.DestroyDuration));

			OnDestroyEvent?.Invoke();
		}
		public void Shrink()
		{
			StartCoroutine(Scale(Vector3.one * Config.SmallScale, Config.ScaleDuration));

			gameObject.layer = LayerMask.NameToLayer("SmallBits");

			OnShrinkEvent?.Invoke();
		}
		public void Grow()
		{
			StartCoroutine(Scale(Vector3.one * Config.NormalScale, Config.ScaleDuration));

			gameObject.layer = LayerMask.NameToLayer("Bits");

			OnGrowEvent?.Invoke();
		}

		private IEnumerator ChangeColor(Color newColor, float duration)
		{
			var timer = new Timer(duration);

			while (timer.RemainingSeconds > 0f)
			{
				_spriteRenderer.color = Color.Lerp(_spriteRenderer.color, newColor, duration * Time.deltaTime);

				timer.Tick(Time.deltaTime);
				yield return null;
			}
		}

		private IEnumerator Scale(Vector3 newScale, float duration)
		{
			var timer = new Timer(duration);

			while (timer.RemainingSeconds > 0f)
			{
				transform.localScale = Vector3.Lerp(transform.localScale, newScale, duration * Time.deltaTime);

				timer.Tick(Time.deltaTime);
				yield return null;
			}
		}
		
		private IEnumerator Despawn(float waitDuration)
		{
			waitDuration += 0.16f;

			var timer = new Timer(waitDuration);

			while (timer.RemainingSeconds > 0f)
			{
				timer.Tick(Time.deltaTime);
				yield return null;
			}

			Config.RemoveWeight();
			ObjectPool.Despawn(gameObject);
		}

		private void GetReferences()
		{
			_collider = GetComponent<CapsuleCollider2D>();
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_spriteChanger = GetComponent<SpriterChanger>();
		}
		private void SetupObject()
		{
			transform.localScale = new Vector3(Config.NormalScale, Config.NormalScale, 1f);

			_collider.enabled = true;
			_collider.offset = Config.ColliderOffset;
			_collider.size = Config.ColliderSize;

			_spriteRenderer.color = Config.NormalColor;
			
			_spriteChanger.spriteCollection = Config.Sprites;

			gameObject.layer = LayerMask.NameToLayer("Bits");
		}

		[ContextMenu("Setup")]
		private void InspectorSetup()
		{
			GetReferences();
			SetupObject();
		}
	}
}
