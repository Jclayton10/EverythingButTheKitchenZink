using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameObject pauseMenuUI;
    public void Start()
    {
        pauseMenuUI = GameObject.Find("Pause UI");
        pauseMenuUI.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Resume()
    {
        Debug.Log("Resuming");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
    }
    public void Exit()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
