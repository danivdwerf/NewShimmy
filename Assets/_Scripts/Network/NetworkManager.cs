using UnityEngine;
using UnityEngine.SceneManagement;

using System;
using System.Collections.Generic;

public class NetworkManager : Photon.PunBehaviour
{
    public Action<bool> OnLoad;
    public Action<Action> JoinedRoom;
    public Action<string> OnFeedback;

    [SerializeField]private string playerPrefabName;
    [SerializeField]private bool dontDestroyOnLoad = true;

    [SerializeField]private bool autoJoinLobby = true;
    [SerializeField]private bool offline = false;

    private NetworkPosition[] networkPositions;

    private void Start()
    {
        this.load(true);
        this.networkPositions= GameObject.FindObjectsOfType<NetworkPosition>();

        if (this.dontDestroyOnLoad)
            DontDestroyOnLoad(this);
        
        this.connect();
    }
        
    private void connect()
    {
        PhotonNetwork.autoJoinLobby = this.autoJoinLobby;
        PhotonNetwork.offlineMode = this.offline;

        if(!this.offline)
            PhotonNetwork.ConnectUsingSettings(NetworkValues.VERSION);
    }

    private void OnJoinedLobby()
    {
        this.load(false);
    }

    public void createRoom(string roomName)
    {
        if (PhotonNetwork.GetRoomList().Length >= NetworkValues.MAXROOMS)
            return;
        
        this.load(true);
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)NetworkValues.MAX_PLAYERS;
        PhotonNetwork.CreateRoom(roomName, options, null);
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
        var spawnTransform = networkPositions[UnityEngine.Random.Range(0, networkPositions.Length)]; 
        PhotonNetwork.Instantiate(this.playerPrefabName, spawnTransform.Postion, spawnTransform.Rotation, 0);
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
