using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour 
{
    [SerializeField]private float xOffset = 0.0f;
    [SerializeField]private float yOffset = 0.0f;
    [SerializeField]private float zOffset = 0.0f;
    [SerializeField]private Transform objectToFollow;

    [SerializeField]private bool lerp = true;
    [SerializeField]private float lerpTime = 10.0f;

    private void Update()
    {
        if (objectToFollow == null)
            return;
        
        var desiredPos = new Vector3(objectToFollow.position.x - xOffset, objectToFollow.position.y - yOffset, objectToFollow.position.z - zOffset);

        if (!lerp)
        {
            this.transform.position = desiredPos;
            return;
        }

        this.transform.position = Vector3.Lerp(this.transform.position, desiredPos, Time.deltaTime * lerpTime);
    }

    public void setTarget(GameObject target)
    {
        this.objectToFollow = target.transform;
    }
}