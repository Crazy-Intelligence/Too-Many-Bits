using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class FollowMouse : MonoBehaviour
	{
		[SerializeField] private Vector3 offset;

		private void Update()
		{
			transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
		}
	}
}
