using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class JoinGameController : MonoBehaviourPunCallbacks
{
    bool publicOrPrivate = false;
    string serverName;
    string passwordName;
    public GameObject inputField;

    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void changePublicOrPrivate()
    {
        publicOrPrivate = !publicOrPrivate;
    }

    public void setServerName(string input)
    {
        serverName = inputField.GetComponent<TMP_InputField>().text; ;
        Debug.Log(serverName);
    }

    public void JoinServer()
    {
        RoomOptions roomOptions = new RoomOptions() { MaxPlayers = 4, IsVisible = !publicOrPrivate, EmptyRoomTtl = 0 };
        //Public Room
        PhotonNetwork.JoinOrCreateRoom(serverName, roomOptions, null);
        if (serverName == "Server Name" || serverName == null)
        {
            PhotonNetwork.JoinRandomOrCreateRoom();
        }

    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("LevelGenerationScene");

        base.OnJoinedRoom();
    }
}
