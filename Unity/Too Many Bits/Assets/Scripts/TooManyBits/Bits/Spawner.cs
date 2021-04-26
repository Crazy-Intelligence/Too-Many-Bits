using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public class Spawner : MonoBehaviour
	{
		public SpawnerConfig config;
		public BitCollection objectInfo;
		
		private Timer _timer;

		private bool disabled;

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
			if (config.spawnRate == 0f)
			{
				enabled = false;
			}

			SetSpawnRate(config.spawnRate);
		}
		private void Update()
		{
			if (disabled) return;

			_timer.Tick(Time.deltaTime);
		}

		public void SetSpawnRate(float newSpawnRate)
		{
			config.spawnRate = newSpawnRate;
			_timer = new Timer(1f / config.spawnRate, true);
			_timer.OnTimerEnd += OnTimerEnd;
		}

		private void Disable() => disabled = true;
		private void Enable() => disabled = false;

		private void OnTimerEnd()
		{
			var spawnTime = 1f / config.spawnRate;

			var overflow = _timer.CountedSeconds / spawnTime;

			for (int i = 1; i < overflow; i++)
			{
				SpawnObject();
			}
		}

		private void SpawnObject()
		{
			var spawnPos = transform.position;

			var newObject = Instantiate(objectInfo.BitPrefab, spawnPos, Quaternion.identity) ;

			var bit = newObject.GetComponent<Bit>();
			bit.Info = objectInfo.GetRandomConfig();

			var rb = newObject.GetComponent<Rigidbody2D>();

			var spawnAngel = Random.Range(config.SpawnDirection - config.SpawnRange, config.SpawnDirection + config.SpawnRange);
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

		

		private void OnDrawGizmosSelected()
		{
			if (config is null) return;

			var minSpawnAngel = config.SpawnDirection - config.SpawnRange;
			var maxSpawnAngel = config.SpawnDirection + config.SpawnRange;

			Vector3 leftVector = transform.position + Rotate(Vector3.down, minSpawnAngel) * config.SpawnForce / 2f;
			Vector3 rightVector = transform.position + Rotate(Vector3.down, maxSpawnAngel) * config.SpawnForce / 2f;

			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position, leftVector);
			Gizmos.DrawLine(transform.position, rightVector);
			Gizmos.DrawLine(leftVector, rightVector);
		}
	}
}
