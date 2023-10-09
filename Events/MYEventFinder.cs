using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

namespace MY.Events
{
    public class MYEventFinder : MonoBehaviour
    {
        [SerializeField]
        private MYEvent Event;

        [SerializeField]
        private List<Object> emitters = new List<Object>();

        [SerializeField]
        private List<Object> listeners = new List<Object>();

        public void List()
        {
            emitters.Clear();
            listeners.Clear();

			FindMono();
			FindSO();
        }

		private void FindMono()
		{
			var monos = FindObjectsOfType<MonoBehaviour>(true);

			foreach (var m in monos)
			{
				var eventFields = m.GetType()
					.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
					.Where(fi => (fi.FieldType == typeof(MYEventEmitter) || fi.FieldType == typeof(MYEventListener)));

				foreach (var f in eventFields)
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

		private void FindSO()
		{
			var initializers = FindObjectsOfType<MYEventInitializer>(true);

			foreach (var i in initializers)
			{
				var listenersSO = i.Listeners;

				foreach (var l in listenersSO)
				{
					foreach (var e in l.MYEvents)
					{
						if (e == Event)
							listeners.Add(l);
					}
				}
			}
		}
    }
}