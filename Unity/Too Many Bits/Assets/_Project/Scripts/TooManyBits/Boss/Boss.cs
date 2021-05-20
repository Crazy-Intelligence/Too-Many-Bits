using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Boss
{
	public class Boss : MonoBehaviour
	{
		[SerializeField] private Counter Weight;
		[SerializeField] private int maxWeight;
		[Space]
		[SerializeField] private float timeUntilSpawn;
		[SerializeField] private float maxActivTime;
		[SerializeField] private float minActiveTime;
		[Space]
		[SerializeField] private Sequence OnSpawnSequence;
		[SerializeField] private Sequence OnDespawnSequence;

		private bool _ticking;
		private bool _spawned;

		private Timer _spawnTimer;
		private Timer _despawnTimer;

		private void Awake()
		{
			_spawnTimer = new Timer(timeUntilSpawn, true);
			_spawnTimer.OnTimerEnd += Spawn;

			_despawnTimer = new Timer(GetActiveTime(), true);
			_despawnTimer.OnTimerEnd += Despawn;
		}

		private void Update()
		{
			OnSpawnSequence.TickTimer(Time.deltaTime);
			OnDespawnSequence.TickTimer(Time.deltaTime);

			if (_ticking == false) return;

			if (_spawned)
			{
				_despawnTimer.Tick(Time.deltaTime);
			}
			else
			{
				if (Weight.Value > maxWeight) return;

				_spawnTimer.Tick(Time.deltaTime);
			}
		}

		[ContextMenu("Spawn")]
		public void Spawn()
		{
			OnSpawnSequence.Start();
			_spawned = true;
		}

		[ContextMenu("Despawn")]
		public void Despawn()
		{
			OnDespawnSequence.Start();
			_spawned = false;
		}

		public void SetTicking(bool value) => _ticking = value;

		private float GetActiveTime() => Random.Range(minActiveTime, maxActivTime);
	}
}
