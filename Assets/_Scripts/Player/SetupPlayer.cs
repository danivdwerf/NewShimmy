using UnityEngine;

public class SetupPlayer : MonoBehaviour 
{
    private void Start()
    {
        this.GetComponent<PlayerMovement>().enabled = true;
        this.GetComponent<PlayerAttack>().enabled = true;
        this.GetComponent<PlayerCam>().enabled = true;

        this.enabled = false;
    }
}
