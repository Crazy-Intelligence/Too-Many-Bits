using UnityEngine;
using UnityEngine.UI;

namespace CrazyIntelligence.Bits
{
	public class MoneyDisplay : MonoBehaviour
	{
		private Text _text;

		private void Awake()
		{
			_text = GetComponent<Text>();
		}
		private void Update()
		{
			_text.text = Counter.Money.ToString();
		}
	}
}
