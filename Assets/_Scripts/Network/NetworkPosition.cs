using UnityEngine;

[AddComponentMenu("Multiplayer/Network Position")]
public class NetworkPosition : MonoBehaviour 
{
    private Transform networkTransform;
    public Vector3 Postion{get{return this.networkTransform.position;}}
    public Quaternion Rotation{get{return this.networkTransform.rotation;}}
    public Vector3 EulerRotation{get{return this.networkTransform.rotation.eulerAngles;}}

    private void Awake()
    {
        this.gameObject.isStatic = true;
        this.networkTransform = this.transform;
    }
}
