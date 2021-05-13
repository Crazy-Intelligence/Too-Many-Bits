using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	public class SeqeuenceBehaviour : MonoBehaviour
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
