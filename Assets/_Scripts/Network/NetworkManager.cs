using UnityEngine;
using UnityEngine.SceneManagement;

using System;

public class NetworkManager : Photon.PunBehaviour
{
    public Action<bool> OnLoad;
    public Action<Action> JoinedRoom;
    public Action<string> OnFeedback;

    [SerializeField]private string playerPrefabName;
    [SerializeField]private bool dontDestroyOnLoad = true;

    private void Start()
    {
        this.load(true);
        PhotonNetwork.autoJoinLobby = true;
        if (this.dontDestroyOnLoad)
            DontDestroyOnLoad(this);
        this.connect();
    }
        
    private void connect()
    {
        PhotonNetwork.ConnectUsingSettings(NetworkValues.VERSION);
    }

    private void OnJoinedLobby()
    {
        print("Joined lobby");
        this.load(false);
    }

    public void createRoom(string roomName)
    {
        this.load(true);
        PhotonNetwork.CreateRoom(roomName);
    }

    public void OnCreatedRoom()
    {
        print("Created Room");
        this.load(false);
    }

    private void OnPhotonCreateRoomFailed (object[] codeAndMsg)
    {
        showMessage("Failed to create room");
        load(false);
    }

    public void joinRoom(string roomName)
    {
        this.load(true);
        PhotonNetwork.JoinRoom(roomName);
    }

    private void OnJoinedRoom()
    {
        print("Joined room");
        //Load Level

        if (this.JoinedRoom != null)
            this.JoinedRoom(this.levelLoaded);
    }

    private void OnPhotonJoinRoomFailed (object[] codeAndMsg)
    {
        showMessage("Failed to join room");
        load(false);
    }

    private void levelLoaded()
    {
        var networkPosition = GameObject.FindObjectOfType<NetworkPosition>();
        var player = PhotonNetwork.Instantiate(this.playerPrefabName, networkPosition.Postion, networkPosition.Rotation, 0);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerAttack>().enabled = true;
        player.GetComponent<PlayerCam>().enabled = true;
        this.load(false);
    }

    private void load(bool value)
    {
        if (OnLoad != null)
            OnLoad(value);
    }

    private void showMessage(string message)
    {
        if (this.OnFeedback != null)
            this.OnFeedback(message);
    }
}
