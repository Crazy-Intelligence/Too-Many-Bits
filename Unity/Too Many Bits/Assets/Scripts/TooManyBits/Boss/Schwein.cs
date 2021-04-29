using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.TooManyBits.Boss
{
	public class Schwein : MonoBehaviour
	{
		[SerializeField] private UnityEvent OnSpit;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Spit();
			}
		}

		[ContextMenu("Spit")]
		public void Spit()
		{
			OnSpit?.Invoke();
		}
	}
}
