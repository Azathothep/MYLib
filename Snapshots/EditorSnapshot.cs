using UnityEngine;

namespace MY.Snapshots
{
	public class EditorSnapshot : MonoBehaviour
	{
#if UNITY_EDITOR
		[SerializeField]
		private SnapshotContainer container;

		[SerializeField]
		private EditorSnapshot autoLoad;

		[SerializeField]
		private Component[] savedComponents;

		[ExecuteInEditMode]
		private void Awake()
		{
			RegisterIDs();
		}

		public void SaveSingle(int index)
		{
			if (index < 0 || index >= savedComponents.Length)
				return;

			container.SaveSingle(savedComponents[index]);
		}

		public void LoadSingle(int index)
		{
			if (index < 0 || index >= savedComponents.Length)
				return;

			container.LoadSingle(savedComponents[index]);
		}

		public void SaveAll()
		{
			container.Save(savedComponents);
		}
		
		public void LoadAll()
		{
			container.RegisterInstanceIDs(savedComponents);
			autoLoad?.LoadAll();
			container.Load(savedComponents);
		}

		public void RegisterIDs()
		{
			container.RegisterInstanceIDs(savedComponents);
		}
#endif
	}
}
