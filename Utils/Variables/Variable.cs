using UnityEngine;

namespace MY.Utils
{
	public class Variable<T> : ScriptableObject
	{
		public T Value;

		public static implicit operator T(Variable<T> v) => v.Value;
	}
}