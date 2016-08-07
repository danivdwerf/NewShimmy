using UnityEngine;
using System.Collections;

public class StairHandler : MonoBehaviour 
{
    private Rigidbody rigidBody; 

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "StairUp")
        {
            if (Vector3.Angle(rigidBody.velocity, other.transform.forward) < 90)
            {
                if(rigidBody.velocity.y>0)
                {
                    float ypos = rigidBody.velocity.y;
                    ypos = 0;
                }
            }
        }

        if (other.transform.tag == "StairDown")
        {
            if (Vector3.Angle(rigidBody.velocity, other.transform.forward) < 90)
            {
                rigidBody.AddForce(0, -9000, 0);
            }
        }
    }
}
