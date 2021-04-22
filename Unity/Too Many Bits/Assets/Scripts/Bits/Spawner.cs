using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private List<ObjectWithWeight<BitData>> Bits = new List<ObjectWithWeight<BitData>>();
		[SerializeField] private GameObject bitPrefab;
		[Space]
		[SerializeField] private float spawnRate;
		[Space]
		[SerializeField] [Range(1f, 25f)] private float spawnForce;
		[SerializeField] [Range(-179f, 179f)] private float spawnDirection;
		[SerializeField] [Range(0f, 89f)] private float spawnRange;

		private Timer _timer;

		private void Awake()
		{
			_timer = new Timer(1f / spawnRate, true);
		}
		private void Start()
		{
			if (spawnRate == 0f)
			{
				enabled = false;
			}

			_timer.OnTimerEnd += OnTimerEnd;
		}
		private void Update()
		{
			_timer.Tick(Time.deltaTime);
		}

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

			var newObject = Instantiate(bitPrefab, spawnPos, Quaternion.identity) ;

			var bit = newObject.GetComponent<Bit>();
			bit.Data = GetRandomBitData();

			var rb = newObject.GetComponent<Rigidbody2D>();

			var spawnAngel = Random.Range(spawnDirection - spawnRange, spawnDirection + spawnRange);
			var spawnForceVector = Rotate(Vector2.down, spawnAngel);

			newObject.SetActive(true);

			rb.AddForce(spawnForceVector * spawnForce, ForceMode2D.Impulse);
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

			foreach (var obj in Bits)
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
			var minSpawnAngel = spawnDirection - spawnRange;
			var maxSpawnAngel = spawnDirection + spawnRange;

			Vector3 leftVector = transform.position + Rotate(Vector3.down, minSpawnAngel) * spawnForce / 2f;
			Vector3 rightVector = transform.position + Rotate(Vector3.down, maxSpawnAngel) * spawnForce / 2f;

			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position, leftVector);
			Gizmos.DrawLine(transform.position, rightVector);
			Gizmos.DrawLine(leftVector, rightVector);
		}
	}
}
