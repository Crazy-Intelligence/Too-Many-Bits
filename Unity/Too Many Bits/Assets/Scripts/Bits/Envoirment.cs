using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Envoirment : MonoBehaviour
	{
		[SerializeField] private Explosion explosion;

		private List<Rigidbody2D> rbs = new List<Rigidbody2D>();

		private void OnEnable()
		{
			GameManager.OnGameOver += Destroy;
		}
		private void OnDisable()
		{
			GameManager.OnGameOver -= Destroy;
		}
		private void Start()
		{
			foreach (var rb in transform.GetComponentsInChildren<Rigidbody2D>())
			{
				rbs.Add(rb);
			}
		}

		private void Destroy()
		{
			foreach (var rb in rbs)
			{
				rb.isKinematic = false;
			}

			explosion.Explode();
		}
	}
}
