using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	public class SequenceBehaviour : MonoBehaviour
	{
		[SerializeField] private Sequence sequence;

		private void Update()
		{
			sequence.TickTimer(Time.deltaTime);
		}

		[ContextMenu("StartSeqeuence")]
		public void StartSeqeuence()
		{
			sequence.Start();
		}
	}
}
