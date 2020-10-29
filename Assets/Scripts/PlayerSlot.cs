using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSlot : MonoBehaviour
{
    //Temp
    public Text ActorNumberText;
    public Text NicknameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerToSlot(Player player)
    {
        NicknameText.text += player.NickName;
        ActorNumberText.text += player.ActorNumber;
    }

    public void RemovePlayerFromSlot()
    {
        NicknameText.text = "Empty Slot";
        ActorNumberText.text = "Empty Slot";
    }
}