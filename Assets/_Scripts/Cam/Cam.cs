using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class Cam:MonoBehaviour
    {
        [SerializeField] private Transform target;
        /*
        private int lookSpeed = 200;

        Vector3 startPosition;
        Vector3 offset;

        float rotateBackDelay = 5;
        float timer;

        void Start()
        {
            startPosition = transform.position;
            offset = transform.position - target.position;
        }

        void Update()
        {
            float xInput = Mathf.Clamp(Input.GetAxis("RightStickHorizontal"), -0.1f, 0.1f);

            if (Mathf.Abs(xInput) != 0.1)
            {
                timer += Time.deltaTime;

                if (timer > rotateBackDelay)
                {
                    Vector3 targetPosition = target.position + offset;

                    transform.position = Vector3.Lerp(transform.position, targetPosition, 1f * Time.deltaTime);
                    

                }
            }

        }
        */
        void LateUpdate()
        {
            /*
            if (target == null)
            {
                Debug.LogError("Put player in the targetslot, Retard!!, Script: Cam.cs");
                return;
            }

            float x = Mathf.Clamp(Input.GetAxis("RightStickHorizontal"), -1, 1);

            if (x < -.0999f)
            {
                transform.RotateAround(target.position, Vector3.up, Time.deltaTime * lookSpeed);
                timer = 0;
            }
            else if (x > .0999f)
            {
                transform.RotateAround(target.position, Vector3.down, Time.deltaTime * lookSpeed);
                timer = 0;
            }
            */
            transform.LookAt(target);
        }
    }
}