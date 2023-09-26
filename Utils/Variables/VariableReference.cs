namespace MY.Utils
{
	[System.Serializable]
	public class VariableReference<T>
	{
		public bool UseConstant = true;
		public T ConstantValue;
		public Variable<T> Variable;

		public T Value
		{
			get { return UseConstant ?	ConstantValue :
										Variable.Value; }
		}

		public static implicit operator T(VariableReference<T> v) => v.Value;
	}
}