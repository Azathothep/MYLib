using log4net.Config;
using System.Collections.Generic;
using UnityEngine;

namespace MY.Events
{
    [CreateAssetMenu(fileName = "MYEvent", menuName = "MY/Events/Event")]
    public class MYEvent : ScriptableObject
    {
        [SerializeField]
        private bool Log = false;

        [SerializeField]
        private bool Mute = false;

        private string log;

        [SerializeField]
        private string devNotes;

        [SerializeField]
        private System.Action onLog;

        private List<System.Action> actions = new List<System.Action>();

        [SerializeField]
        private MYEventOption[] options;

        public void Raise(Object emitter = null)
        {
            if (Mute) return;

            if (RunOptions() == false) return;

            if (Log)
            {
                string caller = emitter ? emitter.ToString() : "button";
                log += "[" + caller + "] raised event\n";
            }

            for (int i = actions.Count - 1; i >= 0; i--)
                actions[i]();
        }

        private bool RunOptions()
        {
            foreach (var option in options)
            {
                if (option.Evaluate(this) == false)
                {
                    log += "Event invalidated by option " + option;
                    return false;
                }
            }

            return true;
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
            Debug.Log("Log cleaned");
        }

        public string GetLog() => log;
    }
}
