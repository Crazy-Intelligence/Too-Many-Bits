using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class RandomColor : MonoBehaviour
	{
		private SpriteRenderer _spriteRenderer;

		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}
		private void Start()
		{
			var randomColor = new Color()
			{
				r = Random.Range(0f, 255f) / 255f,
				g = Random.Range(0f, 255f) / 255f,
				b = Random.Range(0f, 255f) / 255f,
				a = 1f
			};

			_spriteRenderer.color = randomColor;
		}
	}
}
