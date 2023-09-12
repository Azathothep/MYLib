using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MY.Snapshots
{

	// Undo
	// remove instanceIDs serialization
	// Non only in editor ? :(

	[CreateAssetMenu(fileName = "SnapshotContainer", menuName = "MY/Snapshot/SnapshotContainer", order = 0)]
	public class SnapshotContainerSO : ScriptableObject
	{
#if UNITY_EDITOR
		[SerializeField]
		[ReadOnlyInspector]
		private List<string> serializedComponents = new List<string>();

		[SerializeField]
		[ReadOnlyInspector]
		private List<int> instancesIDs = new List<int>();

		[SerializeField]
		[ReadOnlyInspector]
		private int componentSaved = 0;

		private string ToJson(UnityEngine.Component component)
		{
			string json = UnityEditor.EditorJsonUtility.ToJson(component);

			return json;
		}

		public void SaveSingle(UnityEngine.Component component)
		{
			int i = 0;
			string json = ToJson(component);

			for (; i < instancesIDs.Count; i++)
			{
				if (instancesIDs[i] == component.GetInstanceID())
				{
					Debug.Log($"Overwritten 1 component");
					serializedComponents[i] = json;
					break;
				}
			}

			if (i >= instancesIDs.Count)
			{
				serializedComponents.Add(json);
				instancesIDs.Add(component.GetInstanceID());
				Debug.Log($"Saved 1 new component");
			}

			componentSaved = serializedComponents.Count;
			
			EditorUtility.SetDirty(this);
		}

		public void LoadSingle(UnityEngine.Component component)
		{
			int i = 0;

			for (; i < instancesIDs.Count; i++)
			{
				if (instancesIDs[i] == component.GetInstanceID())
				{
					Debug.Log($"Loaded 1 component");
					UnityEditor.EditorJsonUtility.FromJsonOverwrite(serializedComponents[i], component);
					EditorUtility.SetDirty(component);
					break;
				}
			}
		}

		public void Save(UnityEngine.Component[] savedComponents) {
			serializedComponents.Clear();
			
			for (int i = 0; i < savedComponents.Length; i++)
			{
				string json = ToJson(savedComponents[i]);
				serializedComponents.Add(json);
			}

			RegisterInstanceIDs(savedComponents);

			componentSaved = serializedComponents.Count;

			EditorUtility.SetDirty(this);

			Debug.Log($"Saved {componentSaved} components!");
		}

		public void RegisterInstanceIDs(UnityEngine.Component[] savedComponents)
		{
			instancesIDs.Clear();

			for (int i = 0; i < savedComponents.Length; i++)
				instancesIDs.Add(savedComponents[i].GetInstanceID());
		}

		public void Load(UnityEngine.Component[] components)
		{
			if (components.Length != serializedComponents.Count)
			{
				Debug.LogWarning($"Component list ({components.Length}) different from serialized list ({serializedComponents.Count}): components loading aborted");
				return;
			}

			for (int i = 0; i < serializedComponents.Count; i++)
			{
				UnityEditor.EditorJsonUtility.FromJsonOverwrite(serializedComponents[i], components[i]);
				EditorUtility.SetDirty(components[i]);
			}

			Debug.Log($"Loaded {serializedComponents.Count} components!");
		}
#endif
	}
}
