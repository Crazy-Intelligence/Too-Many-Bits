using UnityEngine;
using UnityEngine.UI;

namespace CrazyIntelligence.TooManyBits
{
	public class CounterDisplay : MonoBehaviour
	{
		[SerializeField] private Counter counter;

		private Text _text;

		private void Awake()
		{
			_text = GetComponent<Text>();
		}

		private void Update()
		{
			_text.text = counter.Count.ToString();
		}
	}
}
