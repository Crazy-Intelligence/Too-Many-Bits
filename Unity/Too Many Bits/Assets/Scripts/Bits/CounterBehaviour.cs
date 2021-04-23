using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class CounterBehaviour : MonoBehaviour
	{
		public void AddWeight(int amount) => Counter.AddWeight(amount);
		public void RemoveWeight(int amount) => Counter.RemoveWeight(amount);

		public void AddScore(int amount) => Counter.AddScore(amount);
		public void RemoveScore(int amount) => Counter.RemoveScore(amount);

		public void AddMoney(int amount) => Counter.AddMoney(amount);
		public void RemoveMoney(int amount) => Counter.RemoveMoney(amount);
	}
}
