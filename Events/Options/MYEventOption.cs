using UnityEngine;

namespace MY.Events
{
    public abstract class MYEventOption : ScriptableObject
    {
        public abstract bool Evaluate(MYEvent eventRef);
    }
}
