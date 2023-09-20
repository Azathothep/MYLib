using UnityEditor;
using UnityEngine;

namespace MY.Snapshots
{
	[CustomEditor(typeof(SnapshotContainer))]
	public class SnapshotContainerEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			SerializedProperty serCompProp = serializedObject.FindProperty("serializedComponents");

			GUI.enabled = false;

			int count = serCompProp.arraySize;
			for (int i = 0; i < count; i++)
			{
				EditorGUILayout.PropertyField(serCompProp.GetArrayElementAtIndex(i));
			}

			GUI.enabled = true;
		}
	}
}