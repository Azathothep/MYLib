using UnityEngine;

namespace MY.Events
{
	[CreateAssetMenu(fileName = "PlayOnceOption", menuName = "MY/Events/Options/PlayOnce")]
	public class PlayOnceEventOption : MYEventOption
	{
		private bool played = false;

		public override bool Evaluate(MYEvent eventRef)
		{
			if (played)
				return false;

			played = true;

			return true;
		}
	}
}
