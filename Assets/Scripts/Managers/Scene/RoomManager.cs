using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Singleton;
    public GameObject PhotonPlayerPrefab;

    private List<Player> _roomPlayers = new List<Player>(); 

    private void Awake()
    {
        Singleton = this;

    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            _roomPlayers.Add(player);
            UiManagerRoom.Singleton.SetPlayerSlot(player);
        }
        UiManagerRoom.Singleton.SetRoomInfo(PhotonNetwork.IsMasterClient, PhotonNetwork.CurrentRoom);
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



    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UiManagerRoom.Singleton.SetPlayerSlot(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UiManagerRoom.Singleton.RemovePlayerSlot(otherPlayer);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        SceneManagerPUN.Singleton.LoadNewScene(SceneName.LobbyScene);
    }
}
