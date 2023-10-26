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
					.Where(fi => (fi.FieldType == typeof(MYEventEmitter)
								|| fi.FieldType == typeof(MYEventEmitter[])
								|| fi.FieldType == typeof(MYEventListener)
								|| fi.FieldType == typeof(MYEventListener[])));

				foreach (var f in eventFields)
				{
					//if (f.FieldType == typeof(MYEventEmitter) && ((MYEventEmitter)f.GetValue(m)).EventRef == Event)
					if (IsEmitting(f, m, Event))
					{
						emitters.Add(m);
					}
					//else if (f.FieldType == typeof(MYEventListener) && ((MYEventListener)f.GetValue(m)).EventRef == Event)
					else if (IsListening(f, m, Event))
					{
						listeners.Add(m);
					}
				}
			}
		}

		private bool IsEmitting(FieldInfo f, MonoBehaviour m, MYEvent Event)
		{
			if (f.FieldType == typeof(MYEventEmitter) && ((MYEventEmitter)f.GetValue(m)).EventRef == Event)
				return true;

			if (f.FieldType == typeof(MYEventEmitter[]))
			{
				for (int i = 0; i < ((MYEventEmitter[])f.GetValue(m)).Length; i++)
				{
					if (((MYEventEmitter[])f.GetValue(m))[i].EventRef == Event)
						return true;
				}
			}

			return false;
		}

		private bool IsListening(FieldInfo f, MonoBehaviour m, MYEvent Event)
		{
			if (f.FieldType == typeof(MYEventListener) && ((MYEventListener)f.GetValue(m)).EventRef == Event)
				return true;

			if (f.FieldType == typeof(MYEventListener[]))
			{
				for (int i = 0; i < ((MYEventListener[])f.GetValue(m)).Length; i++)
				{
					if (((MYEventListener[])f.GetValue(m))[i].EventRef == Event)
						return true;
				}
			}


			return false;
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