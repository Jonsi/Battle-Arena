using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class UiManagerRoom : MonoBehaviour
{
    public static UiManagerRoom Singleton;

    public Text MasterText;
    public List<PlayerSlot> PlayerSlotsList;
    public Text RoomName;

    private void Awake()
    {
        Singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //ClearAllPlayerSlots();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetRoomInfo(bool isMaster, Room room)// Transfer to UiManager
    {
        MasterText.text += isMaster;

        RoomName.text = RoomName.text + room.Name + "\n Open: " +
                                        room.IsOpen + "\n Visible: " +
                                        room.IsVisible + "\n max Players" +
                                        room.MaxPlayers;
    }

    public void OnLeaveButtonClcicked()
    {
        RoomManager.Singleton.LeaveRoom();
    }
   
    public void SetPlayerSlot(Player player)
    {
        PlayerSlotsList[player.ActorNumber - 1].SetPlayerToSlot(player);
    }

    public void RemovePlayerSlot(Player player)
    {
        PlayerSlotsList[player.ActorNumber - 1].RemovePlayerFromSlot();
    }

    public void ClearAllPlayerSlots()
    {
        foreach (PlayerSlot slot in PlayerSlotsList)
        {
            slot.RemovePlayerFromSlot();
        }
    }
}
