using UnityEngine;

namespace MY.Events
{
	public class MYEventInitializer : MonoBehaviour
	{
		[SerializeField]
		private MYEventListenerSO[] listenersSO;

		public MYEventListenerSO[] Listeners => listenersSO;

		private void OnEnable()
		{
			foreach (var listener in listenersSO)
			{
				listener.Load();
			}
		}

		private void OnDisable()
		{
			foreach (var listener in listenersSO)
			{
				listener.Unload();
			}
		}
	}
}

