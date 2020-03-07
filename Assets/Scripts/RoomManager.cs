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
    public Button StartGameButton; //Temporary => create automatic delay to start game when MinimumStartCount (number of player)  are int the room
    public PhotonView PV;

    public int StartTimeDelay = 5;

    private void Awake()
    {
        Singleton = this;
    }

    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
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

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined Room");
    }
}
