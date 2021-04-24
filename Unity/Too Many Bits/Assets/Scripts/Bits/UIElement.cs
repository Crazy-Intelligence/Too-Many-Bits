using UnityEngine;

namespace CrazyIntelligence.Bits
{
	[RequireComponent(typeof(Animator))]
	public class UIElement : MonoBehaviour
	{
		private Animator _animator;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}

		[ContextMenu("Show")]
		public void Show()
		{
			_animator.SetTrigger("Show");
		}
		[ContextMenu("Hide")]
		public void Hide()
		{
			_animator.SetTrigger("Hide");
		}
	}
}
