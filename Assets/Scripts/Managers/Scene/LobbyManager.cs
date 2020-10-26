using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public static LobbyManager Singleton;
    public Button JoinGameButton;
    public Text LobbyName;
    public List<Text> RoomsList;

    public byte maxRoomPlayers = 4;
    public int maxRoomsNumber = 4;
    
    private void Awake()
    {
        Singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        AuthenticationValues values = new AuthenticationValues();
        values.UserId = "Jonsi" + Random.Range(0f, 1f);
        PhotonNetwork.AuthValues = values;
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected To Master. ID: ");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinLobby();

    }

    public void OnJoinButtonClicked()
    {
        PhotonNetwork.JoinRandomRoom();
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
        
        var roomName = "Room" + Random.Range(0f, maxRoomsNumber);
        PhotonNetwork.CreateRoom(roomName,roomOptions);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed Creating Room");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        if (PhotonNetwork.IsMasterClient)
        {
            SceneManagerPUN.Singleton.LoadNewScene(SceneName.RoomScene);
        }
    }

    public override void OnJoinedLobby()
    {
        LobbyName.text = PhotonNetwork.CurrentLobby.ToString() +"\n Region: " + 
                         PhotonNetwork.CloudRegion + "\n Ver: " + 
                         PhotonNetwork.GameVersion ;
        
        
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
            
         foreach(RoomInfo room in roomList)
        {
            RoomsList[roomList.IndexOf(room)].text = room.Name;
        }
    }
}
