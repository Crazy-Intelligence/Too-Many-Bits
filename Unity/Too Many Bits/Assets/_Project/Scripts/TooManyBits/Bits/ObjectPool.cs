using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Bits
{
	public static class ObjectPool
	{
		private static Queue<GameObject> _pool = new Queue<GameObject>();

		public static GameObject Spawn(GameObject prefab)
		{
			if (_pool.Count == 0)
			{
				return CreateNew(prefab);
			} 
			else
			{
				return SpawnFromPool();
			}
		}

		public static void Despawn(GameObject gameObject)
		{
			gameObject.SetActive(false);
			_pool.Enqueue(gameObject);
		}

		private static GameObject CreateNew(GameObject prefab)
		{
			return Object.Instantiate(prefab);
		}
		private static GameObject SpawnFromPool()
		{
			return _pool.Dequeue();
		}
	}
}
