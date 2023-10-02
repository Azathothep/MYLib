using UnityEngine;

namespace MY.Events
{
    [System.Serializable]
    public class MYEventListener
    {
        public MYEvent EventRef;

        public void Register(System.Action onEventRaised, MonoBehaviour mono) => EventRef?.RegisterListener(onEventRaised, mono);

        public void Unregister(System.Action onEventRaised, MonoBehaviour mono) => EventRef?.UnregisterListener(onEventRaised, mono);
    }
}