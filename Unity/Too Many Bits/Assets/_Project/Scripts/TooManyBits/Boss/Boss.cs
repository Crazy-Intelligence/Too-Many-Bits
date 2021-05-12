using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits.Boss
{
	public class Boss : MonoBehaviour
	{
		[SerializeField] private UnityEvent OnSpawn;

		public void Spawn()
		{
			OnSpawn?.Invoke();
		}
	}
}
