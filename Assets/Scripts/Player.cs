using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviourPunCallbacks
{
    private void Update()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal") * 10f * Time.deltaTime;
            float z = Input.GetAxis("Vertical") * 10f * Time.deltaTime;
            transform.Translate(x, 0, z);
        }
    }
}
