using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{

    public GameObject target;
    public bool orbitY = false;
    public int lookSpeed = 30;

    void Start()
    {

    }

    void Update()
    {
        float x = Mathf.Clamp(Input.GetAxis("RightStickHorizontal"),-1,1);

        transform.LookAt(target.transform.position);

        if (x < -.0999f)
        {
            transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * lookSpeed);
        }

        if (x > .0999f)
        {
            transform.RotateAround(target.transform.position, Vector3.down, Time.deltaTime * lookSpeed);
        }
    }
}