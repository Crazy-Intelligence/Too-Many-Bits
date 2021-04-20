using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpriterChanger : MonoBehaviour
	{
		[SerializeField] private Sprite spriteA;
		[SerializeField] private Sprite spriteB;
		[Space]
		[SerializeField] private float minIntervall;
		[SerializeField] private float maxIntervall;

		private float _flipIntervall;

		private SpriteRenderer _spriteRenderer;

		private float _passedTime;

		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}
		private void Start()
		{
			_flipIntervall = Random.Range(minIntervall, maxIntervall);
		}
		private void Update()
		{
			_passedTime += Time.deltaTime;

			if (_passedTime >= _flipIntervall)
			{
				if (_spriteRenderer.sprite == spriteA)
				{
					_spriteRenderer.sprite = spriteB;
				}
				else
				{
					_spriteRenderer.sprite = spriteA;
				}

				_flipIntervall = Random.Range(minIntervall, maxIntervall);
				_passedTime = 0f;
			}
		}
	}
}
