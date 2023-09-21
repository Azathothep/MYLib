using System.Threading.Tasks;
using UnityEngine;

namespace MY.Events
{
    [CreateAssetMenu(fileName = "DelayOption", menuName = "MY/Events/Options/Delay")]
    public class DelayEventOption : MYEventOption
    {
        [SerializeField]
        private float delay;

        private bool isDelaying = false;
        private bool hasWaited = false;

		public override bool Evaluate(MYEvent eventRef)
        {
            if (hasWaited)
            {
                hasWaited = false;
                return true;
            }
            else if (isDelaying)
            {
                return false;
            }

            isDelaying = true;
            RaiseAfterDelay(eventRef);

            return false;
        }

        private async void RaiseAfterDelay(MYEvent eventRef)
        {
            await Task.Delay((int)(delay * 1000));
            hasWaited = true;
            isDelaying = false;
            eventRef.Raise();
        }
    }
}
