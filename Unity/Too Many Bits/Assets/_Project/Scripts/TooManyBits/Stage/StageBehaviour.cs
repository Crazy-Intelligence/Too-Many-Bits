using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	public class StageBehaviour : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer[] sprites;
		[SerializeField] [Range(0, 500)] private int minimumWeight;
		[SerializeField] private Counter weight;

		private GameManagerBehaviour _gameManager;

		private bool _disabled;

		private void Awake()
		{
			_gameManager = FindObjectOfType<GameManagerBehaviour>();
		}

		private void Update()
		{
			if (_disabled) return;

			ChangeColor();
		}

		public void Disable()
		{
			_disabled = true;
		}
		public void Enable()
		{
			_disabled = false;
		}

		private void ChangeColor()
		{
			if (weight.Value < minimumWeight) return;

			var weightPercent = (float)(weight.Value - minimumWeight) / (float)(_gameManager.WeightUntilGameOver - minimumWeight);

			var color = new Color(1f, 1f - weightPercent, 1f - weightPercent, 1f);

			foreach (var sprite in sprites)
			{
				sprite.color = color;
			}
		}
	}
}
