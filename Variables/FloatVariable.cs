using UnityEngine;

namespace MY.Variables
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "MY/Variables/Float")]
    public class FloatVariable : ScriptableObject
    {
        public float Value;

        public static implicit operator float(FloatVariable fv) => fv.Value;
    }
}
