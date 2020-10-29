using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public static LobbyManager Singleton;

    public byte maxRoomPlayers = 4;
    public int maxRoomsNumber = 4;
    
    private void Awake()
    {
        Singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        string info = PhotonNetwork.CurrentLobby.ToString() + "\n Region: " +
                         PhotonNetwork.CloudRegion + "\n Ver: " +
                         PhotonNetwork.GameVersion;

        UiManagerLobby.Singleton.SetLobbyInfo(info);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed Joining Room : \n" + message);
        CreateRoom();
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = maxRoomPlayers;
        roomOptions.PublishUserId = true;
        roomOptions.PlayerTtl = 0;
        
        var roomName = "Room" + Random.Range(0f, maxRoomsNumber);
        PhotonNetwork.CreateRoom(roomName,roomOptions);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed Creating Room");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        if (PhotonNetwork.IsMasterClient)
        {
            SceneManagerPUN.Singleton.LoadNewScene(SceneName.RoomScene);
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UiManagerLobby.Singleton.SetRoomList(roomList);
    }

    public void ConnectUsingInfo(PlayerInfo info)
    {
        if (PhotonNetwork.IsConnected)
        {
            return;
        }

        AuthenticationValues values = new AuthenticationValues();
        values.UserId = info.UserId;
        PhotonNetwork.ConnectUsingSettings();
    }
}
