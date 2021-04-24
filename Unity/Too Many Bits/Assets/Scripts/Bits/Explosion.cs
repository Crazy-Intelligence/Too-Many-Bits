using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(PointEffector2D), typeof(CircleCollider2D))]
	public class Explosion : MonoBehaviour
	{
		[SerializeField] private float force;
		[SerializeField] private float effectDuration;

		private CircleCollider2D _collider;
		private PointEffector2D _effector;
		private Timer _timer;

		private bool _active;

		private void Awake()
		{
			_collider = GetComponent<CircleCollider2D>();
			_effector = GetComponent<PointEffector2D>();

			_timer = new Timer(effectDuration);
		}
		private void Start()
		{
			ActivateForce(false);

			_effector.forceMagnitude = force;

			_timer.OnTimerEnd += OnTimerEnd;
		}

		private void Update()
		{
			if (!_active) return;

			_timer.Tick(Time.deltaTime);
		}

		public void Explode()
		{
			_active = true;
			ActivateForce(true);
		}

		private void OnTimerEnd()
		{
			_active = false;

			ActivateForce(false);

			_timer.Reset();
		}

		private void ActivateForce(bool activate)
		{
			_collider.enabled = activate;
			_effector.enabled = activate;
		}
	}
}
