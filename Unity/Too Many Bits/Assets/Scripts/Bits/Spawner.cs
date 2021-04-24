using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private SpawnerInfo info;
		public SpawnerObjectInfo objectInfo;

		[Range(0, 100)] public float spawnRate;
		
		private Timer _timer;

		private bool disabled;

		private void Awake()
		{
			Disable();
		}
		private void OnEnable()
		{
			GameManager.OnStart += Enable;
			GameManager.OnReset += Enable;
			GameManager.OnGameOver += Disable;
		}
		private void OnDisable()
		{
			GameManager.OnStart -= Enable;
			GameManager.OnReset -= Enable;
			GameManager.OnGameOver -= Disable;
		}

		private void Start()
		{
			if (spawnRate == 0f)
			{
				enabled = false;
			}

			_timer = new Timer(1f / spawnRate, true);
			_timer.OnTimerEnd += OnTimerEnd;
		}
		private void Update()
		{
			if (disabled) return;

			_timer.Tick(Time.deltaTime);
		}

		private void Disable() => disabled = true;
		private void Enable() => disabled = false;

		private void OnTimerEnd()
		{
			var spawnTime = 1f / spawnRate;

			var overflow = _timer.CountedSeconds / spawnTime;

			for (int i = 1; i < overflow; i++)
			{
				SpawnObject();
			}
		}

		private void SpawnObject()
		{
			var spawnPos = transform.position;

			var newObject = Instantiate(objectInfo.Prefab, spawnPos, Quaternion.identity) ;

			var bit = newObject.GetComponent<Bit>();
			bit.Data = GetRandomBitData();

			var rb = newObject.GetComponent<Rigidbody2D>();

			var spawnAngel = Random.Range(info.SpawnDirection - info.SpawnRange, info.SpawnDirection + info.SpawnRange);
			var spawnForceVector = Rotate(Vector2.down, spawnAngel);

			newObject.SetActive(true);

			rb.AddForce(spawnForceVector * info.SpawnForce, ForceMode2D.Impulse);
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

		private BitData GetRandomBitData()
		{
			var objects = new List<BitData>();

			foreach (var obj in objectInfo.Distribution)
			{
				for (int i = 0; i < obj.Weight; i++)
				{
					objects.Add(obj.Object);
				}
			}

			var randomIndex = Random.Range(0, objects.Count - 1);

			return objects[randomIndex];
		}

		private void OnDrawGizmosSelected()
		{
			if (info is null) return;

			var minSpawnAngel = info.SpawnDirection - info.SpawnRange;
			var maxSpawnAngel = info.SpawnDirection + info.SpawnRange;

			Vector3 leftVector = transform.position + Rotate(Vector3.down, minSpawnAngel) * info.SpawnForce / 2f;
			Vector3 rightVector = transform.position + Rotate(Vector3.down, maxSpawnAngel) * info.SpawnForce / 2f;

			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position, leftVector);
			Gizmos.DrawLine(transform.position, rightVector);
			Gizmos.DrawLine(leftVector, rightVector);
		}
	}
}
