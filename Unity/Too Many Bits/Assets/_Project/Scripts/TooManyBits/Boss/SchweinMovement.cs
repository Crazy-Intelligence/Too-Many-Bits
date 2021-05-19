using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Boss
{
	public class SchweinMovement : MonoBehaviour
	{
		[SerializeField] private float moveSpeed;
		[SerializeField] private Vector3[] positions;
		[SerializeField] private Vector3 originPosition;

		private bool _moveToOrigin;
		private int _current;

		private void Update()
		{
			transform.position = Vector3.MoveTowards(transform.position, GetTargetPosition(), moveSpeed * Time.deltaTime);
		}

		public void MoveToOrigin() => _moveToOrigin = true;
		public void MoveFromOrigin() => _moveToOrigin = false;

		private Vector3 GetTargetPosition()
		{
			if (_moveToOrigin) return originPosition;

			if (Vector3.Distance(transform.position, positions[_current]) <= 0.1f)
			{
				_current++;
			}

			if (_current >= positions.Length)
			{
				_current = 0;
			}

			return positions[_current];
		}

		private void OnDrawGizmosSelected()
		{
			if (positions.Length == 0) return;

			Gizmos.color = Color.green;

			foreach (var pos in positions)
			{
				Gizmos.DrawWireSphere(pos, 1f);
			}

			Gizmos.color = Color.yellow;

			Gizmos.DrawWireSphere(originPosition, 1f);
		}
	}
}
