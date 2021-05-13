using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Boss
{
	public class Schwein : MonoBehaviour
	{
		[SerializeField] private Sequence SpawnSequence;
		[SerializeField] private Sequence SpitSequence;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Spit();
			}

			SpawnSequence.TickTimer(Time.deltaTime);
			SpitSequence.TickTimer(Time.deltaTime);
		}

		public void Spawn()
		{
			gameObject.SetActive(true);
			SpawnSequence.Start();
		}

		[ContextMenu("Spit")]
		public void Spit()
		{
			SpitSequence.Start();
		}
	}
}
