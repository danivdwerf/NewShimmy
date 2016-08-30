using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour 
{
    private bool isClose;
    [SerializeField] private GameObject visual;  

	void Start () 
    {
        isClose = false;
        visual.SetActive(false);
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
            PlayerStates.playerStates.LevelUp();
            visual.SetActive(true);
            Destroy(gameObject);
            StartCoroutine(DeleteVisual());
        }
	}

    IEnumerator DeleteVisual()
    {
        yield return new WaitForSeconds(2f);
        visual.SetActive(false);
    }
}
