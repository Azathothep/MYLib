using UnityEngine;

namespace MY.Events
{
    [System.Serializable]
    public class MYEventEmitter
    {
        public MYEvent EventRef;
        public void Raise(Object caller) => EventRef?.Raise(caller);
    }
}