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

		private Rigidbody2D _rigidbody;
		private CapsuleCollider2D _collider;
		private SpriteRenderer _spriteRenderer;
		private SpriterChanger _spriteChanger;

		private Timer _timer;

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
		private void Update()
		{
			if (_timer is null) return;
			if (Config.IsInsideBoundary(transform.position)) return;

			_timer.Tick(Time.deltaTime);
		}

		public void DeleteImmediatly()
		{
			StartCoroutine(DespawnRoutine(0f));
		}

		public void Destroy()
		{
			StartCoroutine(ChangeColorRoutine(Config.DestroyedColor, Config.DestroyDuration));

			_collider.enabled = false;

			StartCoroutine(DespawnRoutine(Config.DestroyDuration));

			OnDestroyEvent?.Invoke();
		}
		public void Shrink()
		{
			StartCoroutine(ScaleRoutine(Vector3.one * Config.SmallScale, Config.ScaleDuration));

			_rigidbody.mass = Config.SmallMass;

			gameObject.layer = LayerMask.NameToLayer("SmallBits");

			OnShrinkEvent?.Invoke();
		}
		public void Grow()
		{
			StartCoroutine(ScaleRoutine(Vector3.one * Config.NormalScale, Config.ScaleDuration));

			_rigidbody.mass = Config.NormalMass;

			gameObject.layer = LayerMask.NameToLayer("Bits");

			OnGrowEvent?.Invoke();
		}

		private IEnumerator ChangeColorRoutine(Color newColor, float duration)
		{
			var timer = new Timer(duration);

			while (timer.RemainingSeconds > 0f)
			{
				_spriteRenderer.color = Color.Lerp(_spriteRenderer.color, newColor, (timer.ElapsedSeconds / duration));

				timer.Tick(Time.deltaTime);
				yield return null;
			}
		}

		private IEnumerator ScaleRoutine(Vector3 newScale, float duration)
		{
			var timer = new Timer(duration);

			while (timer.RemainingSeconds > 0f)
			{
				transform.localScale = Vector3.Lerp(transform.localScale, newScale, (timer.ElapsedSeconds / duration));

				timer.Tick(Time.deltaTime);
				yield return null;
			}
		}
		
		private IEnumerator DespawnRoutine(float waitDuration)
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
			_rigidbody = GetComponent<Rigidbody2D>();
			_collider = GetComponent<CapsuleCollider2D>();
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_spriteChanger = GetComponent<SpriterChanger>();
		}
		private void SetupObject()
		{
			transform.localScale = new Vector3(Config.NormalScale, Config.NormalScale, 1f);

			_rigidbody.mass = Config.NormalMass;

			_collider.enabled = true;
			_collider.offset = Config.ColliderOffset;
			_collider.size = Config.ColliderSize;

			_spriteRenderer.color = Config.NormalColor;
			StartCoroutine(ChangeSortingLayerRoutine());

			_spriteChanger.spriteCollection = Config.Sprites;

			gameObject.layer = LayerMask.NameToLayer("Bits");

			_timer = new Timer(Config.MaxTimeOutSideBoundary);
			_timer.OnTimerEnd += Destroy;
		}

		private IEnumerator ChangeSortingLayerRoutine()
		{
			yield return new WaitForSeconds(2f);

			_spriteRenderer.sortingLayerName = "Bits";
		}

		[ContextMenu("Setup")]
		private void InspectorSetup()
		{
			GetReferences();
			SetupObject();
		}
	}
}
