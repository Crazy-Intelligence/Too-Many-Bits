using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.Bits
{
	public class GameOverTrigger : MonoBehaviour
	{
		[SerializeField] private int trigger;
		[SerializeField] private UnityEvent OnGameOverEvent;

		private void Update()
		{
			if (WeightCounter.Weight >= trigger)
			{
				OnGameOverEvent?.Invoke();
			}
		}
	}
}
