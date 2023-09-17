using UnityEngine;

namespace MY.Events
{
    public class MYEventEmitterMB : MonoBehaviour
    {
        public void RaiseEvent(MYEvent eventRef) => this.Raise(eventRef);
    }
}
