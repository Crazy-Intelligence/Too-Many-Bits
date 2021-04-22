using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpriterChanger : MonoBehaviour
	{
		public SpriteCollection spriteCollection;
		[Space]
		[SerializeField] private float timeUntilChange;

		private Timer _timer;

		private SpriteRenderer _spriteRenderer;

		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_timer = new Timer(timeUntilChange, true);
		}
		private void Start()
		{
			ChangeSpriteToRandom();
			_timer.OnTimerEnd += OnTimerEnd;
		}

		private void Update()
		{
			_timer.Tick(Time.deltaTime);
		}

		private void OnTimerEnd()
		{
			ChangeSpriteToRandom();
		}

		private void ChangeSpriteToRandom()
		{
			_spriteRenderer.sprite = spriteCollection.GetRandomSprite();
		}

	}
}
