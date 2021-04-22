using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Vacuum : MonoBehaviour
	{
		[SerializeField] private int scoreMultiplier;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			var bit = collision.GetComponent<Bit>();

			if (bit is null) return;

			ScoreCounter.IncrementScore(bit.Data.BaseValue * scoreMultiplier);

			Destroy(collision.gameObject);
		}

		private void OnDrawGizmos()
		{
			var r = 252f / 255f;
			var g = 165f / 255f;
			var b = 3f / 255f;

			var collider = GetComponent<BoxCollider2D>();

			var offset = new Vector3(collider.offset.x, collider.offset.y);

			Gizmos.color = new Color(r, g, b);
			Gizmos.DrawWireCube(transform.position + offset, collider.size * collider.transform.lossyScale);
		}
	}
}
