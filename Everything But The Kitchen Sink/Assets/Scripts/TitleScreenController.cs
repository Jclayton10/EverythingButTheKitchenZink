using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public void StartSinglePlayer()
    {
        PhotonNetwork.OfflineMode = true;
        PhotonNetwork.JoinRoom("Single Player Room");
        SceneManager.LoadScene("LevelGenerationScene");
    }
    public void StartMultiPlayer()
    {
        PhotonNetwork.OfflineMode = false;
        SceneManager.LoadScene("Multiplayer");
    }
    public void StartSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
