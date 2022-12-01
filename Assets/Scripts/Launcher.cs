using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;
    public Text roomName;

    private void Start()
    {
        //Подключение
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Фотон подключен");
    }

    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.JoinRandomOrCreateRoom();
        Debug.Log("Зашёл как мастер");

    }

    //public override void OnConnected()
    //{
    //    PhotonNetwork.JoinRandomRoom();
    //}

    public override void OnJoinedRoom()
    {
        //if (!PhotonNetwork.IsMasterClient)
        //    PhotonNetwork.JoinRoom("MyGame");
        var a = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        Debug.Log(a);
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        Debug.Log("успешно зашли в комнату");
    }

    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsOpen = true;
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = 6;

            PhotonNetwork.CreateRoom(roomName.text, roomOptions, TypedLobby.Default);
            PhotonNetwork.LoadLevel(1);
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void ConnectToRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRoom(roomName.text);
            PhotonNetwork.LoadLevel(1);

        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    private void Update()
    {
        //PhotonNetwork.GetCustomRoomList(TypedLobby.Default, null);
        //var list = PhotonNetwork.PlayerList;
        //foreach (var item in list)
        //{
        //    Debug.Log(item.NickName);
        //}
    }
}
