using UnityEngine;

namespace MY.Events
{
	[CreateAssetMenu(fileName = "RelayerOption", menuName = "MY/Events/Options/Relayer")]
	public class RelayerEventOption : MYEventOption
	{
		[SerializeField]
		private MYEvent relayedEvent;


		public override bool Evaluate(MYEvent eventRef)
		{
			relayedEvent.Raise(this);

			return true;
		}
	}
}
