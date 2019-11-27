using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class Network : Photon.MonoBehaviour {

    public string gameVersion;

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings(gameVersion);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Fail Join Room");

        RoomOptions option = new RoomOptions();

        option.IsVisible = true;
        option.IsOpen = true;
        option.MaxPlayers = 4;

        PhotonNetwork.CreateRoom("roomName", option, TypedLobby.Default);
    }
    void OnJoinedRoom()
    {
        Debug.Log("Join Room");
    }
}
