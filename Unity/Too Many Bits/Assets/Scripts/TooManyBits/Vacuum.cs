using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Vacuum : MonoBehaviour
	{
		public int ScoreMultiplier;
		public int MoneyMultiplier;
		[SerializeField] private bool doNotDisable;
		[SerializeField] private bool destroyBits;
		[SerializeField] private bool disableColliderOnContact;

		private Collider2D _collider;

		private void Awake()
		{
			_collider = GetComponent<Collider2D>();
		}

		private void OnEnable()
		{
			GameManager.OnReset += Enable;
			GameManager.OnGameOver += Disable;
		}
		private void OnDisable()
		{
			GameManager.OnReset -= Enable;
			GameManager.OnGameOver -= Disable;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			var bit = collision.GetComponent<Bit>();

			if (bit is null) return;

			var score = bit.Data.ScoreValue * ScoreMultiplier;
			Counter.AddScore(score);
			Counter.AddMoney(bit.Data.MoneyValue * MoneyMultiplier);

			if (destroyBits)
			{
				bit.Destroy();
			}
			else
			{
				bit.Collect();
			}

			if (disableColliderOnContact)
			{
				collision.GetComponent<Collider2D>().enabled = false;
			}
		}

		private void Disable()
		{
			if (doNotDisable) return;

			_collider.enabled = false;
		}

		private void Enable()
		{
			_collider.enabled = true;
		}
	}
}
