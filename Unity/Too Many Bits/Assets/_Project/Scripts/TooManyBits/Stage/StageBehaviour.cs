using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	public class StageBehaviour : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D[] parts;

		private Vector3[] _defaultPositions;
		private float[] _defaultRotations;

		private void Start()
		{
			_defaultPositions = new Vector3[parts.Length];
			_defaultRotations = new float[parts.Length];

			for (int i = 0; i < parts.Length; i++)
			{
				_defaultPositions[i] = parts[i].position;
				_defaultRotations[i] = parts[i].rotation;
			}
		}

		public void FallApart()
		{
			foreach (var rb in parts)
			{
				rb.isKinematic = false;
			}
		}

		public void ResetParts()
		{
			for (int i = 0; i < parts.Length; i++)
			{
				parts[i].isKinematic = true;
				parts[i].Sleep();
				parts[i].position = _defaultPositions[i];
				parts[i].rotation = _defaultRotations[i];
			}
		}
	}
}
