using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

namespace MY.Events
{
    public class MYEventSearcher : MonoBehaviour
    {
        //[ReadOnly]
        [SerializeField]
        private List<MonoBehaviour> emitters = new List<MonoBehaviour>();

        [SerializeField]
        private MYEventRef Event;

        //[Button]
        public void List()
        {
            emitters.Clear();

            var monos = FindObjectsOfType<MonoBehaviour>();

            foreach (var m in monos)
            {
                var fields = m.GetType()
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                    .Where(fi => fi.FieldType == typeof(MYEventEmitter));

                foreach (var f in fields)
                {
                    if (((MYEventEmitter)f.GetValue(m)).EventRef == Event)
                    {
                        //Debug.Log("Found " + Event + " in object " + m);
                        emitters.Add(m);
                    }
                }
            }
        }
    }
}