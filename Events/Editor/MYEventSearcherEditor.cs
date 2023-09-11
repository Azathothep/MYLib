using UnityEngine;
using UnityEditor;

namespace MY.Events
{
    [CustomEditor(typeof(MYEventSearcher))]
    public class MYEventSearcherEditor: Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Search"))
            {
                MYEventSearcher searcher = target as MYEventSearcher;
                searcher.List();
            }
        }
    }
}