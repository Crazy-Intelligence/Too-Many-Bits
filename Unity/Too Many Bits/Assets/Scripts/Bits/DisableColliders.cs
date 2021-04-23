using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class DisableColliders : MonoBehaviour
	{
		[SerializeField] private List<Collider2D> colliders = new List<Collider2D>();

		public void DisableAllColliders()
		{
			foreach (var collider in colliders)
			{
				collider.enabled = false;
			}
		}
	}
}
