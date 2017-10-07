using UnityEngine;

public class PlayerCam : MonoBehaviour 
{
    [SerializeField]private GameObject cameraPrefab;
    private Camera playerCam;
    public Camera PlayerCamera{get{return playerCam;}}

    private void Start()
    {
        GameObject pivotObject = GameObject.Instantiate(cameraPrefab) as GameObject;
        pivotObject.GetComponent<FollowObject>().setTarget(this.gameObject);
        this.playerCam = pivotObject.GetComponentInChildren<Camera>();
    }
}
