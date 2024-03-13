using System;
using NaughtyAttributes;
using UnityEngine;

namespace MY.Scriptables
{
	public abstract class EventReference : ScriptableObject
	{
		public event Action Event;

		[Button]
		public void Raise() => Event?.Invoke();

		public void ClearEvent() => Event = null;
	}

	public abstract class EventReference<T> : ScriptableObject
	{
		public event Action<T> Event;

		[Button]
		public virtual void Raise(T value) => Event?.Invoke(value);

		public void ClearEvent() => Event = null;
	}

	public abstract class EventReference<T, T2> : ScriptableObject
	{
		public event Action<T, T2> Event;

		[Button]
		public void Raise(T value, T2 value2) => Event?.Invoke(value, value2);

		public void ClearEvent() => Event = null;
	}
}