using System.Collections.Generic;
using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpriterChanger : MonoBehaviour
	{
		public SpriteCollection spriteCollection;
		[Space]
		[SerializeField] private float minIntervall;
		[SerializeField] private float maxIntervall;

		private float _flipIntervall;

		private SpriteRenderer _spriteRenderer;

		private float _passedTime;

		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}
		private void Start()
		{
			_flipIntervall = Random.Range(minIntervall, maxIntervall);
			ChangeSpriteToRandom();
		}
		private void Update()
		{
			_passedTime += Time.deltaTime;

			if (_passedTime >= _flipIntervall)
			{
				ChangeSpriteToRandom();

				_flipIntervall = Random.Range(minIntervall, maxIntervall);
				_passedTime = 0f;
			}
		}

		private void ChangeSpriteToRandom()
		{
			_spriteRenderer.sprite = spriteCollection.GetRandomSprite();
		}

	}
}
