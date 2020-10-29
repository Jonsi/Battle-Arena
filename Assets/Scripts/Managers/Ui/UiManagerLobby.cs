using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class UiManagerLobby : MonoBehaviour
{

    public static UiManagerLobby Singleton;

    public Text LobbyName;
    public List<Text> RoomsList;
    public InputField NicknameInputField;

    private void Awake()
    {
        Singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSetButttonClicked()// Temp PlayerInfo
    {
        var userId = NicknameInputField.text + Random.Range((int)0f, (int)100f);
        var nickname = userId;

        PlayerInfo info = new PlayerInfo(nickname, userId);
        PlayerInfo.SetPlayerPref(info);
        PhotonNetwork.NickName = nickname;
        LobbyManager.Singleton.ConnectUsingInfo(info);
    }

    public void SetRoomList(List<RoomInfo> roomList)
    {
        
        foreach (RoomInfo room in roomList)
        {
            if (room.RemovedFromList)
            {
               return;
            }
            RoomsList[roomList.IndexOf(room)].text = room.Name;
        }
    }

    public void SetLobbyInfo(string info)
    {
        LobbyName.text = info;
    }

    public void OnJoinButtonClicked()
    {
        PhotonNetwork.JoinRandomRoom();
    }
}
