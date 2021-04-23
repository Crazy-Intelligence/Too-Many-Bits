using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class VacuumManager : MonoBehaviour
	{
		private List<Vacuum> _vacuums = new List<Vacuum>();

		private void Awake()
		{
			var vacuums = FindObjectsOfType<Vacuum>();
			_vacuums = new List<Vacuum>(vacuums);
		}

		public void DisableAllVacuums()
		{
			foreach (var vacuum in _vacuums)
			{
				vacuum.ScoreMultiplier = 0;
			}
		}
	}
}
