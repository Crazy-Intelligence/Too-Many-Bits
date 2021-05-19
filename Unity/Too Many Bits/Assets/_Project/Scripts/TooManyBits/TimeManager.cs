using UnityEngine;

namespace CrazyIntelligence.TooManyBits
{
	public class TimeManager : MonoBehaviour
	{
		public void StopTime() => SetTimeScale(0f);
		public void ContinueTime() => SetTimeScale(1f);

		private void SetTimeScale(float timeScale)
		{
			Time.timeScale = timeScale;
			Time.fixedDeltaTime = Time.timeScale * 0.02f;
		}
	}
}
