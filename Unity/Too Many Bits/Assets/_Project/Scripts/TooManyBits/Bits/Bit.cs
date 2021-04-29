using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class Bit : MonoBehaviour
	{
		public BitConfig Info;

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
			weight.Add(Info.Weight);
		}
		private void OnDisable()
		{
			GameManager.OnReset -= DestroyThisObject;
			weight.Remove(Info.Weight);
		}

		private void Update()
		{
			if (!_animating) return;

			_timer.Tick(Time.deltaTime);
		}

		public void Destroy()
		{
			PlayAnimation(Info.DestroyAnimation);
			_timer.OnTimerEnd += DestroyThisObject;
		}

		public void Shrink()
		{
			PlayAnimation(Info.CollectAnimation);
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
			transform.localScale = new Vector3(Info.Scale, Info.Scale, 1f);

			_collider.offset = Info.ColliderOffset;
			_collider.size = Info.ColliderSize;

			_spriteRenderer.color = Info.Color;
			_spriteRenderer.sortingLayerName = "Bits";

			_spriteChanger.spriteCollection = Info.SpriteCollection;

			_animator.runtimeAnimatorController = Info.AnimatioController;
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
