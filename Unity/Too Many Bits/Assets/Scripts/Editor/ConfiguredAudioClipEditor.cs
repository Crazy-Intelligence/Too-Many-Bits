/* 
 * Credit:
 * https://github.com/richard-fine/scriptable-object-demo/blob/main/Assets/ScriptableObject/Audio/Editor/AudioEventEditor.cs
 */

using UnityEngine;
using UnityEditor;
using CrazyIntelligence.TooManyBits.Audio;

namespace CrazyIntelligence.TooManyBits
{
	[CustomEditor(typeof(ConfiguredAudioClip), true)]
	public class ConfiguredAudioClipEditor : Editor
	{
		[SerializeField] private AudioSource _previewer;

		public void OnEnable()
		{
			_previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
		}

		public void OnDisable()
		{
			DestroyImmediate(_previewer.gameObject);
		}

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
			if (GUILayout.Button("Preview"))
			{
				((ConfiguredAudioClip)target).Play(_previewer);
			}
			EditorGUI.EndDisabledGroup();
		}
	}
}
