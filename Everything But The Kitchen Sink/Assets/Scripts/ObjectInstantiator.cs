using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ObjectInstantiator : MonoBehaviourPunCallbacks
{
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject spawnedCube = PhotonNetwork.Instantiate(this.name, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
