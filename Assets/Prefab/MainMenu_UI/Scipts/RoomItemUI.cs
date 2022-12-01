using UnityEngine;
using UnityEngine.UI;

public class RoomItemUI : MonoBehaviour
{
    public LobbyManager _lobbyManager;
    [SerializeField] private Text _roomName;

    public void SetName(string roomName)
    {
        _roomName.text = roomName;
    }

    public void OnJoinPressed()
    {
        _lobbyManager.JoinRoom(_roomName.text);
    }
}
