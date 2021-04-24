using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Vacuum : MonoBehaviour
	{
		public int ScoreMultiplier;
		public int MoneyMultiplier;
		[SerializeField] private bool doNotDisable;
		[Space]
		[SerializeField] private bool _alwaysShowGizmo;

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

			Counter.AddScore(bit.Data.ScoreValue * ScoreMultiplier);
			Counter.AddMoney(bit.Data.MoneyValue * MoneyMultiplier);

			Destroy(collision.gameObject);
		}

		private void Disable()
		{
			if (doNotDisable) return;

			_collider.enabled = false;
		}

		private void Enable()
		{
			_collider.enabled = true;
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
