using UnityEngine;
using UnityEngine.UI;

namespace CrazyIntelligence.Bits
{
	public class ScoreCounter : MonoBehaviour
	{
		public static int Score { get; private set; }

		private Text _text;

		private void Awake()
		{
			_text = GetComponent<Text>();
		}

		private void Update()
		{
			_text.text = Score.ToString();
		}

		public static void IncrementScore(int amount)
		{
			Score += amount;
		}
	}
}
