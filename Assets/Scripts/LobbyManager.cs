using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _roomInput;
    [SerializeField] private RoomItemUI _roomItemUIPrefab;
    [SerializeField] private Transform _roomListParent;
    [SerializeField] private PhotonView playerPrefab;

    private List<RoomItemUI> _roomList = new List<RoomItemUI>();

    private void Start()
    {
        Connect();
    }

    #region[PhotonCallBacks]
    public override void OnConnectedToMaster()
    {
        Debug.Log($"����� {PhotonNetwork.NickName} ��������� � ������ �������");
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"����� {PhotonNetwork.NickName} ����������");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log($"����� {PhotonNetwork.NickName} ������������� � �����");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        Debug.Log(@$"����� {PhotonNetwork.NickName}
                ������������� � ������� {PhotonNetwork.CurrentRoom.Name}");
    }
    #endregion

    private void Connect()
    {
        PhotonNetwork.NickName = $"Player{Random.Range(0, 5000)}";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(_roomInput.text) == false)
        {
            RoomOptions options = new RoomOptions
            {
                MaxPlayers = 6
            };
            PhotonNetwork.CreateRoom(_roomInput.text, options, TypedLobby.Default);
            PhotonNetwork.LoadLevel(1);
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
        PhotonNetwork.LoadLevel(1);
    }

    private void UpdateRoomList(List<RoomInfo> roomList)
    {
        // �������� ������������ ������ ������
        for (int i = 0; i < _roomList.Count; i++)
        {
            Destroy(_roomList[i].gameObject);
        }

        _roomList.Clear();

        //������ ����� ������ � ���������� �����������
        for (int i = 0; i < roomList.Count; i++)
        {
            //���������� ������ �������
            if (roomList[i].PlayerCount == 0)
                continue;

            RoomItemUI newRoomItem = Instantiate(_roomItemUIPrefab);
            newRoomItem._lobbyManager = this;
            newRoomItem.SetName(roomList[i].Name);
            newRoomItem.transform.SetParent(_roomListParent);

            _roomList.Add(newRoomItem);
        }
    }
}
