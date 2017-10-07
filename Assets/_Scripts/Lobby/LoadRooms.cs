using System;
using System.Collections.Generic;

using UnityEngine;

public struct OnlineRoom
{
    private string name;
    public string Name{get{return this.name;}}

    public OnlineRoom(string roomName = "New Room")
    {
        this.name = roomName;
    }
};

public class LoadRooms : MonoBehaviour 
{
    public Action<List<OnlineRoom>> OnLoadedRooms;

    public void showRooms()
    {
        var roomList = PhotonNetwork.GetRoomList();
        var rooms = new List<OnlineRoom>();

        for (var i = 0; i < roomList.Length; i++)
        {
            var currentRoom = new OnlineRoom(roomList[i].Name);
            rooms.Add(currentRoom);
        }

        if (OnLoadedRooms != null)
            OnLoadedRooms(rooms);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            this.showRooms();
    }
}
