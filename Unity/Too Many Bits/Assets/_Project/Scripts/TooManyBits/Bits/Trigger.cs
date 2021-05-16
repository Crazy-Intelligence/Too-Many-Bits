using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class Trigger : MonoBehaviour
	{
		[SerializeField] private TriggerBehaviour behaviour;

		private Collider2D _collider;

		private void Awake()
		{
			_collider = GetComponent<Collider2D>();
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			var bit = collision.GetComponent<Bit>();

			if (bit is null) return;

			behaviour.Invoke(bit);
		}

		public void Disable() => _collider.enabled = false;
		public void Enable() => _collider.enabled = true;
	}
}
