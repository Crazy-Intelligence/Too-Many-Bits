using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits.Boss
{
	public class Boss : MonoBehaviour
	{
		public GameObject BossObject;
		[SerializeField] private Counter Weight;
		[SerializeField] private int maxWeight;
		[SerializeField] private float timeUntilSpawn;

		[SerializeField] private Sequence OnSpawnSequence;

		private bool _spawned;
		private bool _ticking;

		private Timer _timer;

		private void Awake()
		{
			BossObject.SetActive(false);

			_timer = new Timer(timeUntilSpawn);
			_timer.OnTimerEnd += Spawn;
		}

		private void Update()
		{
			OnSpawnSequence.TickTimer(Time.deltaTime);

			if (_spawned) return;

			if (_ticking == false || Weight.Value > maxWeight) return;

			_timer.Tick(Time.deltaTime);
		}

		[ContextMenu("Spawn")]
		public void Spawn()
		{
			OnSpawnSequence.Start();
			_spawned = true;
		}

		public void IsTicking(bool value) => _ticking = value;
	}
}
