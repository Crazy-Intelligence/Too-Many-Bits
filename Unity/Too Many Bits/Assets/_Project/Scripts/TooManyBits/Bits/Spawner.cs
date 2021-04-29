using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class Spawner : MonoBehaviour
	{
		public SpawnerConfig config;

		[SerializeField] [Range(-179f, 179f)] private float spawnDirectionOffset;

		private Timer _timer;

		private void Awake()
		{
			Disable();
		}
		private void OnEnable()
		{
			GameManager.OnStart += Enable;
			GameManager.OnReset += Disable;
			GameManager.OnGameOver += Disable;
		}
		private void OnDisable()
		{
			GameManager.OnStart -= Enable;
			GameManager.OnReset -= Disable;
			GameManager.OnGameOver -= Disable;
		}

		private void Start()
		{
			if (config.SpawnRate == 0f)
			{
				enabled = false;
			}

			SetSpawnRate(config.SpawnRate);
		}
		private void Update()
		{
			if (config.disabled) return;

			_timer.Tick(Time.deltaTime);
		}

		public void SetSpawnRate(float newSpawnRate)
		{
			config.SpawnRate = newSpawnRate;
			_timer = new Timer(1f / config.SpawnRate, true);
			_timer.OnTimerEnd += OnTimerEnd;
		}

		private void Disable() => config.disabled = true;
		private void Enable() => config.disabled = false;

		private void OnTimerEnd()
		{
			var spawnTime = 1f / config.SpawnRate;

			var overflow = _timer.CountedSeconds / spawnTime;

			for (int i = 1; i < overflow; i++)
			{
				SpawnObject();
			}
		}

		private void SpawnObject()
		{
			var spawnPos = transform.position;

			var newObject = Instantiate(config.objectInfo.Prefab, spawnPos, Quaternion.identity) ;

			var bit = newObject.GetComponent<Bit>();
			bit.Info = config.objectInfo.GetRandomConfig();

			var rb = newObject.GetComponent<Rigidbody2D>();

			var spawnAngel = Random.Range(GetSpawnDirection() - config.SpawnRange, GetSpawnDirection() + config.SpawnRange);
			var spawnForceVector = Rotate(Vector2.down, spawnAngel);

			newObject.SetActive(true);

			rb.AddForce(spawnForceVector * config.SpawnForce, ForceMode2D.Impulse);
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

		private float GetSpawnDirection()
		{
			return transform.rotation.eulerAngles.z + spawnDirectionOffset;
		}

		private void OnDrawGizmosSelected()
		{
			if (config is null) return;

			var minSpawnAngel = GetSpawnDirection() - config.SpawnRange;
			var maxSpawnAngel = GetSpawnDirection() + config.SpawnRange;

			Vector3 leftVector = transform.position + Rotate(Vector3.down, minSpawnAngel) * config.SpawnForce / 10f;
			Vector3 rightVector = transform.position + Rotate(Vector3.down, maxSpawnAngel) * config.SpawnForce / 10f;

			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position, leftVector);
			Gizmos.DrawLine(transform.position, rightVector);
			Gizmos.DrawLine(leftVector, rightVector);
		}
	}
}
