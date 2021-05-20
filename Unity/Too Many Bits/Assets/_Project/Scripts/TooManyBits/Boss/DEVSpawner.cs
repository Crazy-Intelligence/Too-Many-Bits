using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Boss
{
	public class DEVSpawner : MonoBehaviour
	{
		private Boss _boss;

		private void Awake()
		{
			_boss = FindObjectOfType<Boss>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				_boss.Spawn();
			}

			if (Input.GetKeyDown(KeyCode.Backspace))
			{
				_boss.Despawn();
			}
		}
	}
}
