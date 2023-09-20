using UnityEditor;
using UnityEngine;

namespace MY.Snapshots
{
	[CustomEditor(typeof(EditorSnapshot))]
	public class EditorSnapshotEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			var snapshot = (EditorSnapshot)target;

			var container = serializedObject.FindProperty("container");
			EditorGUILayout.PropertyField(container);

			var autoLoad = serializedObject.FindProperty("autoLoad");
			EditorGUILayout.PropertyField(autoLoad);

			var components = serializedObject.FindProperty("savedComponents");

			int toDelete = -1;

			GUILayout.Space(5);

			GUILayout.Label("Saved Components:");

			for (int i = 0; i < components.arraySize; i++)
			{
				var component = components.GetArrayElementAtIndex(i);
			
				EditorGUILayout.BeginHorizontal();{
					EditorGUILayout.PropertyField(component, GUIContent.none);

					if (GUILayout.Button("S"))
						snapshot.SaveSingle(i);

					if (GUILayout.Button("L"))
						snapshot.LoadSingle(i);

					if (GUILayout.Button("-"))
						toDelete = i;

				} EditorGUILayout.EndHorizontal();
			}

			if (toDelete >= 0)
				components.DeleteArrayElementAtIndex(toDelete);

			EditorGUILayout.BeginHorizontal(); {
				GUILayout.FlexibleSpace();

				if (GUILayout.Button("  Add  "))
					components.InsertArrayElementAtIndex(components.arraySize);

			} EditorGUILayout.EndHorizontal();

			GUILayout.Space(5);

			EditorGUILayout.BeginHorizontal(); {

				if (GUILayout.Button("Save All"))
					snapshot.SaveAll();

			if (GUILayout.Button("Register IDs"))
				snapshot.RegisterIDs();

				if (GUILayout.Button("Load All"))
					snapshot.LoadAll();

			} EditorGUILayout.EndHorizontal();

			serializedObject.ApplyModifiedProperties();
		}
	}
}
