using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class FollowMouse : MonoBehaviour
	{
		[SerializeField] private Vector3 offset;
		[SerializeField] [Range(-179f, 179f)] private float rotationOffset;
		[SerializeField] [Range(1f, 50f)] private float rotationSpeed;
		[SerializeField] [Range(0f, 0.1f)] private float minMagnitudeToRotate;

		private Rigidbody2D _rigidbody;

		private Vector3 _lastMousePosition;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
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
		private void Start()
		{
			_lastMousePosition = GetMousePos();
		}
		private void FixedUpdate()
		{
			//MoveToMouse();

			var mousePos = GetMousePos();


			_rigidbody.MovePosition(mousePos);

			var deltaPos = _lastMousePosition - mousePos;

			if (deltaPos.magnitude >= minMagnitudeToRotate)
			{
				RotateTowards(mousePos);
			}

			_lastMousePosition = mousePos;
		}

		private void RotateTowards(Vector2 targetPosition)
		{
			var targetRotation = GetTargetRotation(targetPosition);

			_rigidbody.SetRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed));
		}
		private Quaternion GetTargetRotation(Vector2 targetPosition)
		{
			Vector2 difference = new Vector3(targetPosition.x, targetPosition.y) - transform.position;
			float rotationAngel = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

			Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotationAngel + rotationOffset);

			return targetRotation;
		}
		private void OnGamePause()
		{
			_rigidbody.simulated = false;
		}
		private void OnGameContinue()
		{
			_rigidbody.simulated = true;
		}
		private void OnGameReset()
		{
			_rigidbody.simulated = true;
		}

		private Vector3 GetMousePos() => Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
	}
}
