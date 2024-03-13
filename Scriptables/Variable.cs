using System;
using UnityEngine;

namespace MY.Scriptables
{
	public class Variable<T> : ScriptableObject
	{
		[SerializeField]
		protected T m_Value;

		public Action<T> OnValueChanged;

		public T Value
		{
			get => m_Value;
			set
			{
				m_Value = value;
				OnValueChanged?.Invoke(value);
			}
		}

		public static implicit operator T(Variable<T> v) => v.Value;
	}
}
