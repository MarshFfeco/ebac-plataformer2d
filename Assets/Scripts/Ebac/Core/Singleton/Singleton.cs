using UnityEngine;

namespace Ebac.Core.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        [Header("MonoBehaviour")]
        public static T Instance;

        private void Awake()
        {
            if (Instance is null)
                Instance = GetComponent<T>();
            else
                Destroy(gameObject);
        }
    }
}
