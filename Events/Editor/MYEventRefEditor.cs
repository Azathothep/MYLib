using UnityEditor;
using UnityEngine;

namespace MY.Events
{
    [CustomEditor(typeof(MYEventRef))]
    public class MYEventRefEditor : Editor
    {
        public override bool RequiresConstantRepaint() => Application.isPlaying;

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            SerializedProperty devNotesProp = serializedObject.FindProperty("devNotes");
            EditorGUILayout.PrefixLabel(new GUIContent("Developer Notes"));
            devNotesProp.stringValue = EditorGUILayout.TextArea(devNotesProp.stringValue, GUILayout.Height(60));

            EditorGUILayout.BeginHorizontal();

            SerializedProperty muteProp = serializedObject.FindProperty("Mute");
            EditorGUILayout.PropertyField(muteProp);

            EditorGUI.BeginDisabledGroup(!Application.isPlaying);
            MYEventRef e = target as MYEventRef;
            if (GUILayout.Button(new GUIContent("Raise Event")))
                e.Raise();
            EditorGUI.EndDisabledGroup();

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(10);

            SerializedProperty enableLogProp = serializedObject.FindProperty("Log");
            EditorGUILayout.PropertyField(enableLogProp);

            SerializedProperty contentLogProp = serializedObject.FindProperty("log");
            EditorGUILayout.TextArea(contentLogProp.stringValue, GUILayout.Height(100));
 
            EditorGUI.BeginDisabledGroup(Application.isPlaying);
            if (GUILayout.Button(new GUIContent("Clean Logs")))
            {
                e.CleanLog();
                Repaint();
            }
            EditorGUI.EndDisabledGroup();

            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }
    }
}
