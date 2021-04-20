using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private GameObject prefab;
		[Space]
		[SerializeField] private float minSpawnTime;
		[SerializeField] private float maxSpawnTime;
		[Space]
		[SerializeField] private float minSpawnRange;
		[SerializeField] private float maxSpawnRange;
		[Space]
		[SerializeField] [Range(1f, 25f)] private float spawnForce;
		[SerializeField] private Vector2 spawnForceVector;

		private float _spawnTime;
		private float _passedTime;

		private void Start()
		{
			_spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
		}
		private void Update()
		{
			_passedTime += Time.deltaTime;

			if (_passedTime >= _spawnTime)
			{
				var spawnPos = transform.position + new Vector3(Random.Range(minSpawnRange, maxSpawnRange), 0f);

				var newObject = Instantiate(prefab, spawnPos, Quaternion.identity);

				var rb = newObject.GetComponent<Rigidbody2D>();

				rb.AddForce(spawnForceVector.normalized * spawnForce, ForceMode2D.Impulse);

				_spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
				_passedTime = 0f;
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position + new Vector3(minSpawnRange, 0f), transform.position + new Vector3(maxSpawnRange, 0f));
			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, transform.position + new Vector3(spawnForceVector.normalized.x, spawnForceVector.normalized.y) * spawnForce / 2);
		}
	}
}
