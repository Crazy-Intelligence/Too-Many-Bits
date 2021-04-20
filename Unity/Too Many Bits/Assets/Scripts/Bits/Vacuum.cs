using UnityEngine;
using UnityEngine.Events;

namespace CrazyIntelligence.Bits
{
	public class Vacuum : MonoBehaviour
	{
		public UnityEvent OnBitDeleted;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Bit"))
			{
				OnBitDeleted?.Invoke();

				Destroy(collision.gameObject);
			}
		}
	}
}
