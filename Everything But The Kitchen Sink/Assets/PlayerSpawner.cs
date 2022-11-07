using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public PhotonView pView;
    public GameObject PlayerInstance;

    [PunRPC]
    public void Start()
    {
        PlayerInstance = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.Euler(0, 0, 0));
        pView = PlayerInstance.GetComponent<PhotonView>();
        if (pView.IsMine)
        {
            FirstPersonMovement fpsmovement = PlayerInstance.GetComponent<FirstPersonMovement>();
            fpsmovement.enabled = true;
        }
    }
}
