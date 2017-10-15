using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("RPG/Lock On Target")]
public class LockOnTarget : MonoBehaviour
{
    [SerializeField]private List<GameObject> targetsInReach;
    private GameObject currentTarget;
    private OrbitalCamera cam;
    private bool targetting;
    private Animator anim;

    private void Start()
    {
        targetsInReach = new List<GameObject>();
        targetting = false;
        cam = this.GetComponent<PlayerCam>().PlayerCamera.GetComponent<OrbitalCamera>();
        this.anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        cam.Disabled = targetting;
        anim.SetBool("strafe", this.targetting);

        if (targetsInReach.Count < 1)
            return;
        
        if (Input.GetButtonDown(Controller.LeftThumb))
            targetting = !targetting;

        if (!targetting)
            return;
        
        currentTarget = targetsInReach[0];
        this.transform.LookAt(currentTarget.transform);
        cam.targetMode(this.transform.rotation.eulerAngles);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "NPC")
            return;

        if (other.isTrigger)
            return;

        if (targetsInReach.Contains(other.gameObject))
            return;
        
        targetsInReach.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Characters"))
            return;
        
        if (other.tag != "NPC")
            return;

        if (other.isTrigger)
            return;
        
        targetsInReach.RemoveAt(targetsInReach.IndexOf(other.gameObject));
        if(currentTarget == other.gameObject)
            targetting = false;
    }
}
