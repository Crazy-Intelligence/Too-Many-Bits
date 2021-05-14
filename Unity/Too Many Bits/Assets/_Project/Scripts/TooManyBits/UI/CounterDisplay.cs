using UnityEngine;
using TMPro;

namespace CrazyIntelligence.TooManyBits.UI
{
	public class CounterDisplay : MonoBehaviour
	{
		[SerializeField] private Counter counter;

		private TMP_Text _text;

		private void Awake()
		{
			_text = GetComponent<TMP_Text>();
		}

		private void Update()
		{
			_text.text = counter.Value.ToString();
		}
	}
}
