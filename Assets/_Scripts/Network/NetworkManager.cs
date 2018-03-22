﻿using UnityEngine;
using UnityEngine.SceneManagement;

using System;
using System.Collections.Generic;

[AddComponentMenu("Networking/Manager")]
public class NetworkManager : Photon.PunBehaviour
{
    private enum PlayerSpawning{Random, Increase}

    public Action<bool> OnLoad;
    public Action<Action> JoinedRoom;
    public Action<string> OnFeedback;

    [SerializeField]private string playerPrefabName = null;
    [SerializeField]private PlayerSpawning spawntype = PlayerSpawning.Random;

    [SerializeField]private bool dontDestroyOnLoad = true;
    [SerializeField]private bool autoJoinLobby = true;
    [SerializeField]private bool offline = false;

    [SerializeField]private GameObject lobby = null;
    [SerializeField]private GameObject game = null;

    private NetworkPosition[] networkPositions;

    private void Awake()
    {
        this.load(true);
        PhotonNetwork.autoJoinLobby = this.autoJoinLobby;
        PhotonNetwork.offlineMode = this.offline;

        this.networkPositions= GameObject.FindObjectsOfType<NetworkPosition>();

        if (this.dontDestroyOnLoad)
            DontDestroyOnLoad(this);
        
        this.connect();
    }
        
    private void connect()
    {
        if (this.offline)
            return;

        PhotonNetwork.ConnectUsingSettings(NetworkValues.VERSION);
    }

    public override void OnJoinedLobby()
    {
        this.load(false);
    }

    public void createRoom(string roomName)
    {
        if (PhotonNetwork.GetRoomList().Length >= NetworkValues.MAXROOMS)
            return;
        
        this.load(true);
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = NetworkValues.MAX_PLAYERS;
        PhotonNetwork.CreateRoom(roomName, options, null);
    }

    public override void OnCreatedRoom()
    {
        this.load(false);
    }

    public override void OnPhotonCreateRoomFailed (object[] codeAndMsg)
    {
        showMessage("Failed to create room");
        load(false);
    }

    public void joinRoom(string roomName)
    {
        this.load(true);
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        if (this.JoinedRoom != null)
            this.JoinedRoom(this.levelLoaded);
    }

    public override void OnPhotonJoinRoomFailed (object[] codeAndMsg)
    {
        showMessage("Failed to join room");
        load(false);
    }

    private void levelLoaded()
    {
        NetworkPosition spawnTransform;
        if (spawntype == PlayerSpawning.Random)
            spawnTransform = networkPositions[UnityEngine.Random.Range(0, networkPositions.Length)];
        else
            spawnTransform = networkPositions[PhotonNetwork.playerList.Length - 1];
        PhotonNetwork.Instantiate(this.playerPrefabName, spawnTransform.Postion, spawnTransform.Rotation, 0);
        this.load(false);
    }

    public override void OnDisconnectedFromPhoton()
    {
        game.SetActive(false);
        lobby.SetActive(true);
        if (!this.offline)
            PhotonNetwork.ConnectUsingSettings(NetworkValues.VERSION);
    }

    private void load(bool value)
    {
        if (OnLoad == null)
            return;

        OnLoad(value);
    }

    private void showMessage(string message)
    {
        if (this.OnFeedback != null)
            this.OnFeedback(message);
    }
}
