using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour 
{
    private bool isClose;

	void Start () 
    {
        isClose = false;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClose = true;        
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isClose = false;        
        }
    }

	void Update () 
    {
        if (Input.GetButtonDown("Submit") && isClose)
        {
            Destroy(gameObject);
            PlayerStates.playerStates.LevelUp();
        }
	}
}
