using UnityEngine;
using CI.Utilities;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class Spawner : MonoBehaviour
	{
		public SpawnerConfig Config;

		private Timer _timer;

		private void OnEnable()
		{
			SpawnerConfig.OnConfigsUpdated += OnConfigsUpdated;
		}
		private void OnDisable()
		{
			SpawnerConfig.OnConfigsUpdated -= OnConfigsUpdated;
		}

		private void Start()
		{
			_timer = new Timer(Config.SpawnTime);
			_timer.OnTimerEnd += OnTimerEnd;
			ResetTimer();
		}
		private void Update()
		{
			if (Config.Disabled) return;

			_timer.Tick(Time.deltaTime);
		}

		public void SpawnObject()
		{
			var newObject = ObjectPool.Spawn(Config.Prefab);

			newObject.transform.position = transform.position;

			var bit = newObject.GetComponent<Bit>();
			bit.Config = Config.Bits.GetRandom();

			newObject.SetActive(true);

			var rb = newObject.GetComponent<Rigidbody2D>();
			ApplySpawnForce(rb);

			var sprite = newObject.GetComponent<SpriteRenderer>();
			sprite.sortingLayerName = Config.StartLayer;
		}

		private void OnConfigsUpdated()
		{
			ResetTimer();
		}

		private void OnTimerEnd()
		{
			var spawnTime = Config.SpawnTime;

			var overflow = _timer.ElapsedSeconds / spawnTime;

			for (int i = 1; i < overflow; i++)
			{
				SpawnObject();
			}

			ResetTimer();
		}

		private void ApplySpawnForce(Rigidbody2D rb)
		{
			var spawnAngel = Random.Range(GetSpawnAngel() - Config.SpawnAngelRange, GetSpawnAngel() + Config.SpawnAngelRange);
			var spawnForceVector = Rotate(Vector2.down, spawnAngel);

			rb.AddForce(spawnForceVector * Config.SpawnForce, ForceMode2D.Impulse);
		}

		private void ResetTimer()
		{
			if (_timer is null) return;
			_timer.Reset(Config.SpawnTime);
		}

		private Vector3 Rotate(Vector3 vector, float angel)
		{
			var q = Quaternion.Euler(0f, 0f, angel);

			var vectorPartOfQ = new Vector3(q.x, q.y, q.z);
			var scalerPartOfQ = q.w;

			var newVector = 2f * Vector3.Dot(vectorPartOfQ, vector) * vectorPartOfQ
							+ ((scalerPartOfQ * scalerPartOfQ) - Vector3.Dot(vectorPartOfQ, vectorPartOfQ)) * vector
							+ 2f * scalerPartOfQ * Vector3.Cross(vectorPartOfQ, vector);

			return newVector;
		}

		private float GetSpawnAngel()
		{
			float offset = Config.SpawnAngelOffset;
			float angel = transform.rotation.eulerAngles.z + offset;
			return angel + offset;
		}

		private void OnDrawGizmosSelected()
		{
			if (Config is null) return;

			var minSpawnAngel = GetSpawnAngel() - Config.SpawnAngelRange;
			var maxSpawnAngel = GetSpawnAngel() + Config.SpawnAngelRange;

			Vector3 leftVector = transform.position + Rotate(Vector3.down, minSpawnAngel) * Config.SpawnForce / 10f;
			Vector3 rightVector = transform.position + Rotate(Vector3.down, maxSpawnAngel) * Config.SpawnForce / 10f;

			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position, leftVector);
			Gizmos.DrawLine(transform.position, rightVector);
			Gizmos.DrawLine(leftVector, rightVector);
		}
	}
}
