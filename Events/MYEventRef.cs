#if MYLIB_NAUGHTYATTRIBUTES_SUPPORT

using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace MY.Events
{
    [CreateAssetMenu(fileName = "MYEvent", menuName = "MY/Events/Event")]
    public class MYEventRef : ScriptableObject
    {
        [SerializeField]
        private bool Log = false;

        [SerializeField]
        [ReadOnly]
        [ResizableTextArea]
        private string log;

        private List<System.Action> actions = new List<System.Action>();

        [Button]
        private void CleanLog()
        {
            log = string.Empty;
        }

        [Button]
        public void Raise(MonoBehaviour emitter = null)
        {
            if (Log) log += "[" + emitter + "] raised event\n";

            for (int i = actions.Count - 1; i >= 0; i--)
                actions[i]();
        }

        public void RegisterListener(System.Action action, MonoBehaviour listener)
        {
            if (actions.Contains(action))
                return;

            actions.Add(action);

            if (Log) log += ("[" + listener + "] registered\n");
        }

        public void UnregisterListener(System.Action action, MonoBehaviour listener)
        {
            int index = actions.IndexOf(action);

            if (index < 0)
                return;

            actions.RemoveAt(index);

            if (Log) log += "[" + listener + "] unregistered\n";
        }
    }
}

#endif
