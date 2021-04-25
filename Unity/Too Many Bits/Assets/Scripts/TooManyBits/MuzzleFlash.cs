using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class MuzzleFlash : MonoBehaviour
	{
		[SerializeField] private SpriteCollection muzzleflashes;
		[Space]
		[SerializeField] private float flashDuration;

		private SpriteRenderer _spriteRenderer;

		private float _passedTime;

		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			if (_spriteRenderer.sprite == null) return;

			_passedTime += Time.deltaTime;

			if (_passedTime >= flashDuration)
			{
				HideFlash();
			}
		}

		public void ShowFlash()
		{
			_spriteRenderer.sprite = muzzleflashes.GetRandomSprite();
			_passedTime = 0f;
		}

		private void HideFlash()
		{
			_spriteRenderer.sprite = null;
		}
	}
}
