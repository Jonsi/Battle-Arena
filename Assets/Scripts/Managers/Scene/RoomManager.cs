using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public static RoomManager Singleton;

    public int MinimumStartCount;//Minimu players in the room for strting game automatically(with delay)
    public Button LeaveRoom;
    public Button StartGameButton;
    public List<Text> RoomSlots;
    public Text RoomName;
    public PhotonView PV;

    public int StartTimeDelay = 5;

    private void Awake()
    {
        Singleton = this;
        
    }


    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Connected to room as master");
        }
        else
        {
            Debug.Log("Connected as player");
        }

        RoomName.text = RoomName.text + PhotonNetwork.CurrentRoom.Name + "\n Open: " +
                                        PhotonNetwork.CurrentRoom.IsOpen + "\n Visible: " +
                                        PhotonNetwork.CurrentRoom.IsVisible + "\n max Players" +
                                        PhotonNetwork.CurrentRoom.MaxPlayers;
        PhotonNetwork.CurrentRoom.AddPlayer(PhotonNetwork.LocalPlayer);
        AddPlayerToSlot();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        SceneManagerPUN.Singleton.LoadNewScene(SceneName.ArenaScene);
    }

    public void AddPlayerToSlot()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            RoomSlots[player.ActorNumber].text = player.UserId;
        }
    }
}
