using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class Collector : MonoBehaviour
	{
		[SerializeField] private CollectorBehaviour behaviour;

		private Collider2D _collider;

		private void Awake()
		{
			_collider = GetComponent<Collider2D>();
		}

		private void OnEnable()
		{
			GameManager.OnReset += Enable;
			GameManager.OnGameOver += Disable;
		}
		private void OnDisable()
		{
			GameManager.OnReset -= Enable;
			GameManager.OnGameOver -= Disable;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			var bit = collision.GetComponent<Bit>();

			if (bit is null) return;

			behaviour.Invoke(bit);
		}

		private void Disable() => _collider.enabled = false;
		private void Enable() => _collider.enabled = true;
	}
}
