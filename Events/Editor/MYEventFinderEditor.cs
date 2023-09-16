using UnityEngine;
using UnityEditor;

namespace MY.Events
{
    [CustomEditor(typeof(MYEventFinder))]
    public class MYEventFinderEditor: Editor
    {
        private bool emittersFold;
        private bool listenersFold;

        public override void OnInspectorGUI()
        {
            SerializedProperty refProp = serializedObject.FindProperty("Event");

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(refProp);

            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();

            EditorGUILayout.Space(10);

            if (GUILayout.Button("Search"))
            {
                MYEventFinder searcher = target as MYEventFinder;
                searcher.List();
            }

            EditorGUILayout.Space(10);

            SerializedProperty emittersProp = serializedObject.FindProperty("emitters");
            SerializedProperty listenersProp = serializedObject.FindProperty("listeners");

            emittersFold = EditorGUILayout.BeginFoldoutHeaderGroup(emittersFold, "Emitters (" + emittersProp.arraySize + ")");
            {
                if (emittersFold)
                {
                    EditorGUI.indentLevel++;
                    EditorGUILayout.BeginVertical(GUI.skin.box);
                    for (int i = 0; i < emittersProp.arraySize; i++)
                    {
                        EditorGUILayout.PropertyField(emittersProp.GetArrayElementAtIndex(i));
                    }
                    EditorGUI.indentLevel--;
                    EditorGUILayout.EndVertical();

                    EditorGUILayout.Space(15);
                }
                EditorGUILayout.EndFoldoutHeaderGroup();
            }

            listenersFold = EditorGUILayout.BeginFoldoutHeaderGroup(listenersFold, "Listeners (" + listenersProp.arraySize + ")");
            {
                if (listenersFold)
                {
                    EditorGUI.indentLevel++;
                    EditorGUILayout.BeginVertical(GUI.skin.box);
                    for (int i = 0; i < listenersProp.arraySize; i++)
                    {
                        EditorGUILayout.PropertyField(listenersProp.GetArrayElementAtIndex(i));
                    }
                    EditorGUI.indentLevel--;
                    EditorGUILayout.EndVertical();

                    EditorGUILayout.Space(15);
                }
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
    }
}