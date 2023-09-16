using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

namespace MY.Events
{
    public class MYEventFinder : MonoBehaviour
    {
        [SerializeField]
        private MYEventRef Event;

        [SerializeField]
        private List<MonoBehaviour> emitters = new List<MonoBehaviour>();

        [SerializeField]
        private List<MonoBehaviour> listeners = new List<MonoBehaviour>();

        public void List()
        {
            emitters.Clear();
            listeners.Clear();

            var monos = FindObjectsOfType<MonoBehaviour>();

            foreach (var m in monos)
            {
                var emittersFields = m.GetType()
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                    .Where(fi => (fi.FieldType == typeof(MYEventEmitter) || fi.FieldType == typeof(MYEventListener)));

                foreach (var f in emittersFields)
                {
                    if (f.FieldType == typeof(MYEventEmitter) && ((MYEventEmitter)f.GetValue(m)).EventRef == Event)
                    {
                        emitters.Add(m);
                    }
                    else if (f.FieldType == typeof(MYEventListener) && ((MYEventListener)f.GetValue(m)).EventRef == Event)
                    {
                        listeners.Add(m);
                    }
                }
            }
        }
    }
}