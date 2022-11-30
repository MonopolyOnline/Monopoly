using Photon.Pun;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;

    private void Start()
    {
        //Подключение
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //Если мы подключились
        Debug.Log("Фотон подключен");
        //PhotonNetwork.CreateRoom("MyGame", null, null);
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    //public override void OnConnected()
    //{
    //    PhotonNetwork.JoinRandomRoom();
    //}

    public override void OnJoinedRoom()
    {
        //if (!PhotonNetwork.IsMasterClient)
        //    PhotonNetwork.JoinRoom("MyGame");
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        Debug.Log("успешно зашли в комнату");
    }
}
