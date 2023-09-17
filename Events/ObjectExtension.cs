using UnityEngine;

namespace MY.Events
{
    public static class ObjectExtension
    {
        public static void Raise(this Object obj, MYEventEmitter Event) => Event.Raise(obj);

        public static void Raise(this Object obj, MYEvent Event) => Event.Raise(obj);
    }
}