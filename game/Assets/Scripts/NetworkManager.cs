using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    // Update is called once per frame
    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Trying to Connect to the Server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server");
        base.OnConnectedToMaster();

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);

    }

    public override void OnJoinedRoom()
    {
        ExitGames.Client.Photon.Hashtable userData = new ExitGames.Client.Photon.Hashtable();
        userData.Add("uid", "123");
        PhotonNetwork.LocalPlayer.SetCustomProperties(userData);
        Debug.Log("You joined a room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room here");
        base.OnPlayerEnteredRoom(newPlayer);
    }

}
