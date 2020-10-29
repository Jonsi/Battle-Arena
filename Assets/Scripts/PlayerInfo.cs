using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InfoKey{
    NickName,
    UserId
}

public class PlayerInfo : MonoBehaviour
{
    public string Nickname { get; private set; }
    public string UserId { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public PlayerInfo(string nickname, string userId)
    {
        Nickname = nickname;
        UserId = userId;
    }

    public PlayerInfo(PlayerInfo playerInfo)
    {
        UpdatePlayerInfo(playerInfo);
    }

    public void UpdatePlayerInfo(PlayerInfo playerInfo)
    {
        SetPlayerInfo(playerInfo);
        SetPlayerPref(playerInfo);
        //Set To Prefab
    }


    public void SetPlayerInfo(PlayerInfo playerInfo)
    {
        Nickname = playerInfo.Nickname;
        UserId = playerInfo.UserId;
    }

    public static void SetPlayerPref(PlayerInfo playerInfo)
    {
        //Set to player Pref
        PlayerPrefs.SetString(InfoKey.NickName.ToString(), playerInfo.Nickname);
        PlayerPrefs.SetString(InfoKey.UserId.ToString(), playerInfo.UserId);
    }

    public PlayerInfo GetPlayerInfo()
    {
        return this;
    }

    public static PlayerInfo GetPlayerPref()
    {
        var nickname = PlayerPrefs.GetString(InfoKey.NickName.ToString());
        var userId = PlayerPrefs.GetString(InfoKey.UserId.ToString());

        return new PlayerInfo(nickname, userId);
    }

}
