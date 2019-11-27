using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonManager : Photon.PunBehaviour
{

    public static PhotonManager instance;
    public static GameObject localPlayer;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;

        PhotonNetwork.automaticallySyncScene = true;
    }
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings("Simulate_v1.0");

    }
    public void JoinGameRoom()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Simulate Room", options, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("당신은 이미 게임에 진입하였습니다");
        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.LoadLevel("NonCapsuleScene");
        }
    }

    void OnLevelWasLoaded(int levelNumber)
    {
        if (!PhotonNetwork.inRoom)
        {
            return;
        }
        Debug.Log("게임에 들어왔어요");

        localPlayer = PhotonNetwork.Instantiate("Capsule", new Vector3(0, 0.5f, 0), Quaternion.identity, 0);
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Master Server 에 연결되었습니다");
    }











}
