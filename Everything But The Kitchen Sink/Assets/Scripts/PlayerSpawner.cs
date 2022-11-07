using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public PhotonView pView;
    public GameObject PlayerInstance;
    public GameObject Camera;

    [PunRPC]
    public void Start()
    {
        PlayerInstance = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.Euler(0, 0, 0));
        pView = PlayerInstance.GetComponent<PhotonView>();
        if (pView.IsMine)
        {
            PlayerInstance.GetComponent<FirstPersonMovement>().enabled = true;
            PlayerInstance.GetComponent<Jump>().enabled = true;
            PlayerInstance.GetComponent<Crouch>().enabled = true;
            PlayerInstance.transform.Find("First Person Camera").GetComponent<Camera>().enabled = true;
            PlayerInstance.transform.Find("First Person Camera").GetComponent<AudioListener>().enabled = true;
        }
    }

}
