using UnityEngine;

namespace MY.Utils
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        protected void Awake()
        {
            if (Instance == null)
                Instance = this as T;
            else
                Destroy(this.gameObject);
        }
    }
}
