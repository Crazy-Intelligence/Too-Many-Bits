using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class BitSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject bitPrefab;
		[Space]
		[SerializeField] private float minSpawnTime;
		[SerializeField] private float maxSpawnTime;
		[Space]
		[SerializeField] private float minSpawnRange;
		[SerializeField] private float maxSpawnRange;

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

				Instantiate(bitPrefab, spawnPos, Quaternion.identity);

				_spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
				_passedTime = 0f;
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position + new Vector3(minSpawnRange, 0f), transform.position + new Vector3(maxSpawnRange, 0f));
		}
	}
}
