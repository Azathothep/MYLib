using UnityEngine;

namespace MY.Scriptables
{
	public class Constant<T> : ScriptableObject
	{
		[SerializeField]
		protected T m_Value;

		public T Value
		{
			get => m_Value;
		}

		public static implicit operator T(Constant<T> v) => v.Value;
	}
}
