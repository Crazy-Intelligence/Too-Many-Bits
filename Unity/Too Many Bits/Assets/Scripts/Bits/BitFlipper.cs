using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class BitFlipper : MonoBehaviour
	{
		[SerializeField] private Sprite zero;
		[SerializeField] private Sprite one;
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
				if (_spriteRenderer.sprite == zero)
				{
					_spriteRenderer.sprite = one;
				}
				else
				{
					_spriteRenderer.sprite = zero;
				}

				_flipIntervall = Random.Range(minIntervall, maxIntervall);
				_passedTime = 0f;
			}
		}
	}
}
