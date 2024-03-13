using UnityEngine;

namespace MY.Scriptables
{
	[System.Serializable]
	public class ConstantReference<T>
	{
		public bool Overwrite = true;

		[SerializeField]
		private T OverwritedValue;

		[SerializeField]
		private Variable<T> Variable;

		public T Value
		{
			get
			{
				return Overwrite ? OverwritedValue :
										Variable.Value;
			}
		}

		public static implicit operator T(ConstantReference<T> v) => v.Value;
	}
}
