using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public PhotonView pView;
    public GameObject PlayerInstance;
    public GameObject Camera;
    public GameObject EnemyAI;

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

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<Pathfinding>().allPlayers.Add(PlayerInstance.transform);
        }

        EnemyAI.SetActive(true);
    }

    public override void OnLeftRoom()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<Pathfinding>().allPlayers.Remove(PlayerInstance.transform);
        }

        base.OnLeftRoom();
    }
}
