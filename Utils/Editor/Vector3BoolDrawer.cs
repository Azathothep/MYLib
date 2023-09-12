using UnityEditor;
using UnityEngine;

namespace MY.Utils
{
    [CustomPropertyDrawer(typeof(Vector3Bool))]
    public class Vector3BoolDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty xProp = property.FindPropertyRelative("x");
            SerializedProperty yProp = property.FindPropertyRelative("y");
            SerializedProperty zProp = property.FindPropertyRelative("z");

            EditorGUI.PrefixLabel(position, label);

            Rect toggleRect = new Rect(position);
            toggleRect.x = EditorGUIUtility.labelWidth + 20 - (15 * EditorGUI.indentLevel);
            toggleRect.width = 40;

            EditorGUI.BeginChangeCheck();
            {
                xProp.boolValue = EditorGUI.ToggleLeft(toggleRect, "X", xProp.boolValue);

                toggleRect.x += 40;
                yProp.boolValue = EditorGUI.ToggleLeft(toggleRect, "Y", yProp.boolValue);

                toggleRect.x += 40;
                zProp.boolValue = EditorGUI.ToggleLeft(toggleRect, "Z", zProp.boolValue);
            }
            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();
        }
    }
}
