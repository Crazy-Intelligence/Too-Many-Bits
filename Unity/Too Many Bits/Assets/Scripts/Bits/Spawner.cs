using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private GameObject prefab;
		[Space]
		[SerializeField] private float spawnRate;
		[Space]
		[SerializeField] [Range(1f, 25f)] private float spawnForce;
		[SerializeField] [Range(-179f, 179f)] private float spawnDirection;
		[SerializeField] [Range(0f, 89f)] private float spawnRange;
		
		private float _spawnTime;
		private float _passedTime;

		private void Start()
		{
			if (spawnRate == 0f)
			{
				enabled = false;
			}

			ResetSpawnTime();
		}
		private void Update()
		{
			_passedTime += Time.deltaTime;

			if (_passedTime >= _spawnTime)
			{
				var overflowCount = _passedTime / _spawnTime;
				
				for (int i = 1; i < overflowCount; i++)
				{
					SpawnObject();
				}

				ResetSpawnTime();
				_passedTime = 0f;
			}
		}

		private void SpawnObject()
		{
			var spawnPos = transform.position;

			var newObject = Instantiate(prefab, spawnPos, Quaternion.identity);

			var rb = newObject.GetComponent<Rigidbody2D>();

			var spawnAngel = Random.Range(spawnDirection - spawnRange, spawnDirection + spawnRange);
			var spawnForceVector = Rotate(Vector2.down, spawnAngel);

			rb.AddForce(spawnForceVector * spawnForce, ForceMode2D.Impulse);
		}

		private void ResetSpawnTime()
		{
			_spawnTime = 1f / spawnRate;
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
