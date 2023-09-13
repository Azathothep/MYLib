using UnityEditor;
using UnityEngine;

namespace MY.Utils
{
    [CustomEditor(typeof(TransformLink))]
    public class TransformLinkEditor: Editor
    {
        public override void OnInspectorGUI()
        {
			EditorGUI.BeginChangeCheck();
			SerializedProperty linkerProp = serializedObject.FindProperty("Linker");
            EditorGUILayout.PropertyField(linkerProp);

            SerializedProperty linkPosProp = serializedObject.FindProperty("linkPosition");
            SerializedProperty linkRotProp = serializedObject.FindProperty("linkRotation");
            SerializedProperty linkScaProp = serializedObject.FindProperty("linkScale");

            EditorGUILayout.PropertyField(linkPosProp);
            if (linkPosProp.boolValue)
            {
                SerializedProperty useOffsetProp = serializedObject.FindProperty("usePositionOffset");
                SerializedProperty constraintsProp = serializedObject.FindProperty("positionConstraints");

                EditorGUI.indentLevel++;

                EditorGUILayout.PropertyField(useOffsetProp);
                EditorGUILayout.PropertyField(constraintsProp);

                EditorGUI.indentLevel--;
                EditorGUILayout.Space();
            }

            EditorGUILayout.PropertyField(linkRotProp);
            if (linkRotProp.boolValue)
            {
                SerializedProperty useOffsetProp = serializedObject.FindProperty("useRotationOffset");
                SerializedProperty constraintsProp = serializedObject.FindProperty("rotationConstraints");

                EditorGUI.indentLevel++;

                EditorGUILayout.PropertyField(useOffsetProp);
                EditorGUILayout.PropertyField(constraintsProp);

                EditorGUI.indentLevel--;
                EditorGUILayout.Space();
            }

            EditorGUILayout.PropertyField(linkScaProp, new GUIContent("Link Local Scale"));
            if (linkScaProp.boolValue)
            {
                SerializedProperty useOffsetProp = serializedObject.FindProperty("useScaleOffset");
                SerializedProperty constraintsProp = serializedObject.FindProperty("scaleConstraints");

                EditorGUI.indentLevel++;

                EditorGUILayout.PropertyField(useOffsetProp);
                EditorGUILayout.PropertyField(constraintsProp);

                EditorGUI.indentLevel--;
                EditorGUILayout.Space();
            }

            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }
    }
}
