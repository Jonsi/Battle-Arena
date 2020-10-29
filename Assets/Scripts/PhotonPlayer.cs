using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonPlayer : MonoBehaviourPunCallbacks
{
    public PlayerInfo PlayerInfo;
    public GameObject AvatarPrefab;
    public PhotonView PV;

    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        InitPlayerInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitPlayerInfo()
    {
        //Get PlayerPref
        PlayerInfo = PlayerInfo.GetPlayerPref();
        PhotonNetwork.NickName = PlayerInfo.Nickname;
    }

}
