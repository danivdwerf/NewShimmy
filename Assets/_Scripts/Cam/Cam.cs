using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class Cam:MonoBehaviour
    {
        [SerializeField] private Transform target;

        void LateUpdate()
        {
            transform.LookAt(target);
        }
    }
}