using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public struct OnlineRoom
{
    private string name;
    public string Name{get{return this.name;}}

    private int size;
    public int Size{get{return this.size;}}

    public OnlineRoom(string roomName = "Room", int size = 0)
    {
        this.name = roomName;
        this.size = size;
    }
};

public class LoadRooms : MonoBehaviour 
{
    [SerializeField]private float refreshRate = 5.0f;
    public Action<List<OnlineRoom>> OnLoadedRooms;

    private void Start()
    {
        this.loadRooms();
        StartCoroutine("refreshRooms");
    }

    public void loadRooms()
    {
        var roomList = PhotonNetwork.GetRoomList();
        var rooms = new List<OnlineRoom>();

        for (var i = 0; i < roomList.Length; i++)
        {
            var currentRoom = new OnlineRoom(roomList[i].Name, roomList[i].PlayerCount);
            rooms.Add(currentRoom);
        }

        if (OnLoadedRooms != null)
            OnLoadedRooms(rooms);
    }

    private IEnumerator refreshRooms()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.refreshRate);
            this.loadRooms();
        }
    }
}
