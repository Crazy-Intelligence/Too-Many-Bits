using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits
{
	[System.Serializable]
	public class ActionsWithDelay
	{
		public float Delay;
		[SerializeField] private UnityEvent Actions;

		public void Invoke()
		{
			Actions?.Invoke();
		}
	}
}
