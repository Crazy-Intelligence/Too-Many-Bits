using UnityEngine;
using System.Collections.Generic;

namespace CrazyIntelligence.Bits
{
	[CreateAssetMenu(fileName = "Sprites", menuName = "Bits/SpriteCollection")]
	public class SpriteCollection : ScriptableObject
	{
		[SerializeField] private List<Sprite> sprites = new List<Sprite>();

		private int _index = 0;

		public Sprite GetRandomSprite()
		{
			if (sprites.Count <= 1)
			{
				return sprites[0];
			}

			if (sprites.Count == 2)
			{
				return GetOtherSprite();
			}

			_index = Random.Range(0, sprites.Count - 1);
			
			return sprites[_index];
		}

		private Sprite GetOtherSprite()
		{
			if (_index == 0)
			{
				_index = 1;
			}
			else
			{
				_index = 0;
			}

			return sprites[_index];
		}
	}
}
