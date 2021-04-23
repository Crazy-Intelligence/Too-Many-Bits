using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Vacuum : MonoBehaviour
	{
		public int ScoreMultiplier;
		[SerializeField] private bool _alwaysShowGizmo;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			var bit = collision.GetComponent<Bit>();

			if (bit is null) return;

			int value = bit.Data.BaseValue * ScoreMultiplier;
			ScoreCounter.Add(value);
			MoneyCounter.Add(value);

			Destroy(collision.gameObject);
		}

		private void OnDrawGizmos()
		{
			if (!_alwaysShowGizmo) return;
			OnDrawGizmosSelected();
		}
		private void OnDrawGizmosSelected()
		{
			DrawCollider();
		}

		private void DrawCollider()
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
