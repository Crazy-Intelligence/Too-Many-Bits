using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class Rotator : MonoBehaviour
	{
		[SerializeField] private float speed;
		[SerializeField] private bool invert;
		[SerializeField] private bool randomOffset;

		private float _rotationAngel;

		private void Start()
		{
			if (randomOffset)
			{
				transform.Rotate(transform.forward, Random.Range(-179f, 179f));
			}
		}

		private void Update()
		{
			_rotationAngel = speed * 10f * Time.deltaTime;

			if (invert)
			{
				_rotationAngel *= -1f;
			}

			transform.Rotate(transform.forward, _rotationAngel);
		}
	}
}
