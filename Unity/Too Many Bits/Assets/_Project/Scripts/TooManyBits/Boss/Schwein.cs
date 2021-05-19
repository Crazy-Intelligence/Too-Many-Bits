using UnityEngine;

namespace CrazyIntelligence.TooManyBits.Boss
{
	public class Schwein : MonoBehaviour
	{
		[SerializeField] private Sequence SpawnSequence;
		[SerializeField] private Sequence DespawnSequence;
		[Space]
		[SerializeField] private Sequence SpitSequence;
		[SerializeField] private Sequence ScreamSequence;

		private void Update()
		{
			SpawnSequence.TickTimer(Time.deltaTime);
			DespawnSequence.TickTimer(Time.deltaTime);
			SpitSequence.TickTimer(Time.deltaTime);
			ScreamSequence.TickTimer(Time.deltaTime);
		}

		[ContextMenu("Spawn")]
		public void Spawn()
		{
			SpawnSequence.Start();
		}

		[ContextMenu("Despawn")]
		public void Despawn()
		{
			DespawnSequence.Start();
		}

		[ContextMenu("Spit")]
		public void Spit()
		{
			SpitSequence.Start();
		}

		[ContextMenu("Scream")]
		public void Scream()
		{
			ScreamSequence.Start();
		}
	}
}
