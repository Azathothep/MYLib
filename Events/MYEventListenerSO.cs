using UnityEngine;

namespace MY.Events
{
	public abstract class MYEventListenerSO : ScriptableObject
	{
		public MYEvent[] MYEvents;

		public abstract void Load();
		public abstract void Unload();
	}
}
