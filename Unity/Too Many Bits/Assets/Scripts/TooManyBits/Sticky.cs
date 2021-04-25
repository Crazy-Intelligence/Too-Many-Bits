using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Sticky : MonoBehaviour
	{
		public bool Active;

		private Collider2D _collider;

		private void Awake()
		{
			_collider = GetComponent<Collider2D>();
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (!Active) return;

			if (collision.otherCollider != _collider) return;

			var bit = collision.gameObject.GetComponent<Bit>();

			if (bit is null) return;

			var bitRb = bit.GetComponent<Rigidbody2D>();
			bitRb.Sleep();

			bit.transform.SetParent(transform);
		}
	}
}
