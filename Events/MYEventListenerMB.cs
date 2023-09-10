using System.Collections;
using UnityEngine;

namespace MY.Events
{
    public class MYEventListenerMB : MonoBehaviour
    {
        [SerializeField]
        private MYEventListener Event;

        private void OnEnable()
        {
            Event.Register(OnEventRaised, this);
        }

        private void OnDisable()
        {
            Event.Unregister(OnEventRaised, this);
        }

        public void OnEventRaised()
        {
            Debug.Log("Event raised");
        }
    }
}