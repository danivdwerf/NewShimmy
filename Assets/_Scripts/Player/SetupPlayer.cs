using UnityEngine;

public class SetupPlayer : Photon.MonoBehaviour 
{
    private void Start()
    {
        if (!photonView.isMine)
        {
            this.enabled = false;
            return;
        }

        this.GetComponent<PlayerCam>().enabled = true;
        this.GetComponent<PlayerMovement>().enabled = true;
        this.GetComponent<PlayerAttack>().enabled = true;

        this.enabled = false;
    }
}
