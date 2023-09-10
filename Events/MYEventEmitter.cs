using System.Collections;
using UnityEngine;

namespace MY.Events
{
    [System.Serializable]
    public class MYEventEmitter
    {
        public MYEventRef EventRef;
        public void Raise(MonoBehaviour caller) => EventRef.Raise(caller);
    }
}