using UnityEngine;

namespace CrazyIntelligence.TooManyBits
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
			_timer.OnTimerEnd += OnTimerEnd;
		}
		private void Start()
		{
			ChangeSpriteToRandom();
		}

		private void Update()
		{
			_timer.Tick(Time.deltaTime);
		}

		public void ChangeSpriteToRandom()
		{
			_spriteRenderer.sprite = spriteCollection.GetRandomSprite();
		}

		private void OnTimerEnd()
		{
			ChangeSpriteToRandom();
		}
	}
}
