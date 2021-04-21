using UnityEngine;

namespace CrazyIntelligence.Bits
{
	public class TimeManager : MonoBehaviour
	{
		public static void SetTimeScale(float timeScale)
		{
			Time.timeScale = timeScale;
			Time.fixedDeltaTime = Time.timeScale * 0.02f;
		}
	}
}
