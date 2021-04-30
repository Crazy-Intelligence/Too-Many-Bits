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
		private Animator _animator;

		private bool _animating;
		private Timer _timer;

		private void Awake()
		{
			GetReferences();
		}

		private void OnEnable()
		{
			SetupObject();

			GameManager.OnReset += DestroyThisObject;
			weight.Add(Config.Weight);
		}
		private void OnDisable()
		{
			GameManager.OnReset -= DestroyThisObject;
			weight.Remove(Config.Weight);
		}

		private void Update()
		{
			if (!_animating) return;

			_timer.Tick(Time.deltaTime);
		}

		public void Destroy()
		{
			PlayAnimation(Config.DestroyAnimation);
			_timer.OnTimerEnd += DestroyThisObject;
		}

		public void Shrink()
		{
			PlayAnimation(Config.CollectAnimation);
		}

		private void GetReferences()
		{
			_collider = GetComponent<CapsuleCollider2D>();
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_spriteChanger = GetComponent<SpriterChanger>();
			_animator = GetComponent<Animator>();
		}
		private void SetupObject()
		{
			transform.localScale = new Vector3(Config.Scale, Config.Scale, 1f);

			_collider.offset = Config.ColliderOffset;
			_collider.size = Config.ColliderSize;

			_spriteRenderer.color = Config.Color;
			_spriteRenderer.sortingLayerName = "Bits";

			_spriteChanger.spriteCollection = Config.SpriteCollection;

			_animator.runtimeAnimatorController = Config.AnimatioController;
		}

		private void PlayAnimation(AnimationClip clip)
		{
			_timer = new Timer(clip.length);
			_timer.OnTimerEnd += OnAnimationEnd;
			_animating = true;
			_animator.Play(clip.name);
		}

		private void OnAnimationEnd()
		{
			_animating = false;
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
