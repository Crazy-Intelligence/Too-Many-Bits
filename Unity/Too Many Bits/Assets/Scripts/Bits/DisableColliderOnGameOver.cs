using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class DisableColliderOnGameOver : MonoBehaviour
	{
		private Collider2D _collider;

		private void Awake()
		{
			_collider = GetComponent<Collider2D>();
		}
		private void OnEnable()
		{
			GameManager.OnReset += EnableCollider;
			GameManager.OnGameOver += DisableCollider;
		}
		private void OnDisable()
		{
			GameManager.OnReset -= EnableCollider;
			GameManager.OnGameOver -= DisableCollider;
		}

		private void EnableCollider() => _collider.enabled = true;
		private void DisableCollider() => _collider.enabled = false;
	}
}
