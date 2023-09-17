using UnityEditor;
using UnityEngine;

namespace MY.Events
{
    [CustomEditor(typeof(MYEvent))]
    public class MYEventEditor : Editor
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
                    bool mute = GUILayout.Toggle(muteProp.boolValue, "Mute", "Button");
                    muteProp.boolValue = mute;

                    EditorGUI.BeginDisabledGroup(!Application.isPlaying);
                        MYEvent e = target as MYEvent;
                        if (GUILayout.Button(new GUIContent("Raise Event")))
                            e.Raise();
                    EditorGUI.EndDisabledGroup();

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.Space(10);

                SerializedProperty options = serializedObject.FindProperty("options");
                EditorGUILayout.PropertyField(options);

                EditorGUILayout.Space(10);

                EditorGUILayout.BeginHorizontal();
                SerializedProperty enableLogProp = serializedObject.FindProperty("Log");
                bool enableLog = GUILayout.Toggle(enableLogProp.boolValue, "Log", "Button");
                enableLogProp.boolValue = enableLog;


                EditorGUI.BeginDisabledGroup(Application.isPlaying);
                if (GUILayout.Button(new GUIContent("Clean Logs")))
                {
                    e.CleanLog();
                    Repaint();
                }
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginVertical();
                    string log = ((MYEvent)target).GetLog();
                    EditorGUILayout.TextArea(log, GUILayout.MinHeight(60));
                EditorGUILayout.EndVertical();
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }
    }
}
