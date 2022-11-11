using Photon.Pun;
using UnityEngine;

public class ObjectInstantiator : MonoBehaviourPunCallbacks
{
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject newGameObject = PhotonNetwork.Instantiate(this.name, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
