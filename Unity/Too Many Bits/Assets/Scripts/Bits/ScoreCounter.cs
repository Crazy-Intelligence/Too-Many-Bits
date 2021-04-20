using UnityEngine;
using UnityEngine.UI;

namespace CrazyIntelligence.Bits
{
	public class ScoreCounter : MonoBehaviour
	{
		public int Score;

		private Text _text;

		private void Awake()
		{
			_text = GetComponent<Text>();
		}

		private void Start()
		{
			_text.text = Score.ToString();
		}

		public void IncrementScore()
		{
			Score++;
			_text.text = Score.ToString();
		}
	}
}
