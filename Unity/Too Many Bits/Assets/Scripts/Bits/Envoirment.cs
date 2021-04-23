using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Envoirment : MonoBehaviour
	{
		private List<Rigidbody2D> rbs = new List<Rigidbody2D>();

		private void Start()
		{
			foreach (var rb in transform.GetComponentsInChildren<Rigidbody2D>())
			{
				rbs.Add(rb);
			}
		}

		public void Destroy()
		{
			foreach (var rb in rbs)
			{
				rb.isKinematic = false;
			}
		}
	}
}
