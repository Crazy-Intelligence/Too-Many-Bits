using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits.Boss
{
	public class Boss : MonoBehaviour
	{
		public GameObject BossObject;
		[SerializeField] private UnityEvent OnSpawnEvent;

		private void Awake()
		{
			BossObject.SetActive(false);
		}

		[ContextMenu("Spawn")]
		public void Spawn()
		{
			OnSpawnEvent?.Invoke();
		}
	}
}
