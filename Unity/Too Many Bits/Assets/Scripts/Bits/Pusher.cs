using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Pusher : MonoBehaviour
	{
		[SerializeField] private Vector3 offset;

		private void Update()
		{
			if (Input.GetMouseButton(0))
			{
				transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
			}
		}
	}
}
