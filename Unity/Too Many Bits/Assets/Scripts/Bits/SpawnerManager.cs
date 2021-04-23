using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class SpawnerManager : MonoBehaviour
	{
		private List<Spawner> _spawners = new List<Spawner>();

		private void Awake()
		{
			var spawner = FindObjectsOfType<Spawner>();
			_spawners = new List<Spawner>(spawner);
		}

		public void DisableAllSpawners()
		{
			foreach (var spawner in _spawners)
			{
				spawner.spawnRate = 0;
			}
		}
	}
}
