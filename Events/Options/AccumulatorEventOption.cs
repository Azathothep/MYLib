using UnityEngine;

namespace MY.Events
{
    [CreateAssetMenu(fileName = "AccumulatorOption", menuName = "MY/Events/Options/Accumulator")]
    public class AccumulatorEventOption : MYEventOption
    {
        [SerializeField]
        private int countNumber;
		private int currentCount = 0;

        [SerializeField]
        private MYEvent relayedEvent;

		public override bool Evaluate(MYEvent eventRef)
        {
            currentCount++;

            if (currentCount == countNumber)
            {
                currentCount = 0;
                relayedEvent.Raise(this);
            }

            return true;
        }
    }
}