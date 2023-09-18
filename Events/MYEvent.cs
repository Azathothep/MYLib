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

		private List<System.Action<Object>> actionsWithObjectArgument = new List<System.Action<Object>>();

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

			for (int i = actionsWithObjectArgument.Count - 1; i >= 0; i--)
				actionsWithObjectArgument[i](emitter);
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

        public void RegisterListener(System.Action action, Object listener)
        {
            if (actions.Contains(action))
                return;

            actions.Add(action);

            if (Log) RegisterLog(listener);
		}

		public void RegisterListener(System.Action<Object> action, Object listener)
		{
			if (actionsWithObjectArgument.Contains(action))
				return;

			actionsWithObjectArgument.Add(action);

			if (Log) RegisterLog(listener);
		}

        public void UnregisterListener(System.Action action, Object listener)
        {
            int index = actions.IndexOf(action);

            if (index < 0)
                return;

            actions.RemoveAt(index);

            if (Log) UnregisterLog(listener);
		}

		public void UnregisterListener(System.Action<Object> action, Object listener)
		{
			int index = actionsWithObjectArgument.IndexOf(action);

			if (index < 0)
				return;

			actionsWithObjectArgument.RemoveAt(index);

			if (Log) UnregisterLog(listener);
		}

		// Log

		private void RegisterLog(Object listener) => log += "[" + listener + "] registered\n";
		private void UnregisterLog(Object listener) => log += "[" + listener + "] unregistered\n";

		public void CleanLog() => log = string.Empty;

        public string GetLog() => log;
    }
}
