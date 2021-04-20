using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class FollowMouse : MonoBehaviour
	{
		[SerializeField] private Vector3 offset;

		private Rigidbody2D _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void FixedUpdate()
		{
			_rigidbody.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset);
		}
	}
}
