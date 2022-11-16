using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SinkSpawner : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find(name + "(Clone)") != null)
            Destroy(gameObject);
        else
        {
            if (PhotonNetwork.IsMasterClient)
            {
                GameObject newGameObject = PhotonNetwork.Instantiate(name, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
