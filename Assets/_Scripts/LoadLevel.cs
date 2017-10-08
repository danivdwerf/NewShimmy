using UnityEngine;
using System;

public class LoadLevel : MonoBehaviour 
{
    [SerializeField]private GameObject lobby;
    [SerializeField]private GameObject level;

    private NetworkManager manager;

    private void Start()
    {
        this.manager = GameObject.FindGameObjectWithTag(Tags.NetworkManager).GetComponent<NetworkManager>();
        manager.JoinedRoom += this.loadLevel; 
        level.SetActive(false);
    }

    private void loadLevel(Action readyCallback)
    {
        lobby.SetActive(false);
        level.SetActive(true);

        if (readyCallback != null)
            readyCallback();
    }
}
