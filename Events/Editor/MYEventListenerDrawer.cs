using UnityEditor;
using UnityEngine;

namespace MY.Events
{
    [CustomPropertyDrawer(typeof(MYEventListener))]
    public class MYEventListenerDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty eventProp = property.FindPropertyRelative("EventRef");

            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, eventProp, new GUIContent(property.name));
            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();
        }
    }
}
