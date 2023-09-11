using UnityEngine;

namespace MY.Events
{
    public static class MonoBehaviourExtension
    {
        public static void Raise(this MonoBehaviour mono, MYEventEmitter Event) => Event.Raise(mono);

        public static void Raise(this MonoBehaviour mono, MYEventRef Event) => Event.Raise(mono);
    }
}
