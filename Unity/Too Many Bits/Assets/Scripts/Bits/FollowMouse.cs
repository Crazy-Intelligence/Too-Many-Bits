using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class FollowMouse : MonoBehaviour
	{
		[SerializeField] private Vector3 offset;

		private Rigidbody2D _rigidbody;

		private Vector3 _lastMousePosition;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}
		private void Start()
		{
			transform.position = GetMousePos();
			ResetOffset();
		}

		private void OnEnable()
		{
			GameManager.OnPause += OnGamePause;
			GameManager.OnContinue += OnGameContinue;
			GameManager.OnReset += OnGameReset;
		}
		private void OnDisable()
		{
			GameManager.OnPause -= OnGamePause;
			GameManager.OnContinue -= OnGameContinue;
			GameManager.OnReset -= OnGameReset;
		}

		private void FixedUpdate()
		{
			MoveToMouse();

			_lastMousePosition = GetMousePos();
		}
		private void OnGamePause()
		{
			_rigidbody.simulated = false;
		}
		private void OnGameContinue()
		{
			_rigidbody.simulated = true;
			OnGameReset();
		}
		private void OnGameReset()
		{
			_lastMousePosition = Vector3.zero;
			ResetOffset();
		}

		private void MoveToMouse()
		{
			if (_lastMousePosition == Vector3.zero) return;

			var mousePosDelta = GetMousePos() - _lastMousePosition;

			_rigidbody.MovePosition(transform.position + mousePosDelta);
		}
		private void ResetOffset()
		{
			var mousePos = GetMousePos();
			offset = new Vector3()
			{
				x = offset.x + mousePos.x,
				y = offset.y + mousePos.y,
				z = offset.z
			};
		}

		private Vector3 GetMousePos() => Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
	}
}
