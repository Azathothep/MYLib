using UnityEngine;
using System.Collections.Generic;

namespace MY.Events
{
	public abstract class MYEventListenerSO : ScriptableObject
	{
		[SerializeField]
		public List<MYEvent> MYEvents;

		public abstract void Load();
		public abstract void Unload();
	}
}
