using UnityEngine;

namespace MY.Utils
{
    [System.Serializable]
    public class Vector3Bool
    {
        public bool x;
        public bool y;
        public bool z;

        public static Vector3Bool False = new Vector3Bool(false, false, false);
        public static Vector3Bool True = new Vector3Bool(true,  true, true);

        public Vector3Bool()
        {
            this.x = false;
            this.y = false;
            this.z = false;
        }

        public Vector3Bool(bool x, bool y, bool z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static explicit operator Vector3(Vector3Bool v3b) => new Vector3(v3b.x ? 1 : 0, v3b.y ? 1 : 0, v3b.z ? 1 : 0);
    }
}
