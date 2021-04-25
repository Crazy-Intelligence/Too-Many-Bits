using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Bit : MonoBehaviour
	{
		public BitData Data;

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
			Counter.AddWeight(Data.Weight);
		}
		private void OnDisable()
		{
			GameManager.OnReset -= DestroyThisObject;
			Counter.RemoveWeight(Data.Weight);
		}

		private void Update()
		{
			if (!_animating) return;

			_timer.Tick(Time.deltaTime);
		}

		public void Destroy()
		{
			PlayAnimation(Data.DestroyAnimation);
			_timer.OnTimerEnd += DestroyThisObject;
		}

		public void Collect()
		{
			PlayAnimation(Data.CollectAnimation);
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
			transform.localScale = new Vector3(Data.Scale, Data.Scale, 1f);

			_collider.offset = Data.ColliderOffset;
			_collider.size = Data.ColliderSize;

			_spriteRenderer.color = Data.Color;
			_spriteRenderer.sortingLayerName = "Bits";

			_spriteChanger.spriteCollection = Data.SpriteCollection;

			_animator.runtimeAnimatorController = Data.AnimatioController;
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
