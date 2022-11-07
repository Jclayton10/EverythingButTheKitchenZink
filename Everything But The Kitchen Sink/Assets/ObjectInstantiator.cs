using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ObjectInstantiator : MonoBehaviourPunCallbacks
{
    [PunRPC]
    void Start()
    {
        GameObject spawnedCube = PhotonNetwork.Instantiate(this.name, transform.position, transform.rotation);
    }
}
