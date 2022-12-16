using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviourPunCallbacks
{
    PlayerManager playerManager = new PlayerManager();
    [SerializeField] Material colorRed;
    [SerializeField] Material colorBlue;

    private void Start()
    {
        if (photonView.IsMine)
        {
            var playerList = PhotonNetwork.PlayerList;
            int pCount = 0;
            foreach (var item in playerList)
            {
                pCount++;
            }
            photonView.name = $"Player {pCount}";
            switch (pCount)
            {
                case 1:
                    photonView.gameObject.GetComponent<Renderer>().material = colorRed;
                    break;
                case 2:
                    photonView.gameObject.GetComponent<Renderer>().material = colorBlue;
                    break;
            }

            photonView.transform.position = new Vector3(-9f, 0f, 4f);
        }
    }

    private void Update()
    {
        //if (photonView.IsMine)
        //{
        //    var playerList = PhotonNetwork.PlayerList;
        //    int pCount = 0;
        //    foreach (var item in playerList)
        //    {
        //        pCount++;
        //    }
        //    photonView.name = $"Player {pCount}";
        //    switch (pCount)
        //    {
        //        case 1:
        //            photonView.gameObject.GetComponent<Renderer>().material = colorRed;
        //            break;
        //        case 2:
        //            photonView.gameObject.GetComponent<Renderer>().material = colorBlue;
        //            break;
        //    }

        //    photonView.transform.position = new Vector3(-9f, 0f, 4f);
        //}
    }
}
