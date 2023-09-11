using System.Collections.Generic;
using UnityEngine;

namespace MY.Events
{
    [CreateAssetMenu(fileName = "MYEvent", menuName = "MY/Events/Event")]
    public class MYEventRef : ScriptableObject
    {
        [SerializeField]
        private bool Log = false;

        [SerializeField]
        private bool Mute = false;

        [SerializeField]
        private string log;

        [SerializeField]
        private string devNotes;

        [SerializeField]
        private System.Action onLog;

        private List<System.Action> actions = new List<System.Action>();

        public void Raise(MonoBehaviour emitter = null)
        {
            if (Mute) return;

            if (Log)
            {
                string caller = emitter ? emitter.ToString() : "button";
                log += "[" + caller + "] raised event\n";
            }

            for (int i = actions.Count - 1; i >= 0; i--)
                actions[i]();
        }

        public void RegisterListener(System.Action action, MonoBehaviour listener)
        {
            if (actions.Contains(action))
                return;

            actions.Add(action);

            if (Log) log += "[" + listener + "] registered\n";
        }

        public void UnregisterListener(System.Action action, MonoBehaviour listener)
        {
            int index = actions.IndexOf(action);

            if (index < 0)
                return;

            actions.RemoveAt(index);

            if (Log) log += "[" + listener + "] unregistered\n";
        }

        public void CleanLog()
        {
            log = string.Empty;
        }
    }
}
