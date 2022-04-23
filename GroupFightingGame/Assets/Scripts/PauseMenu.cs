using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    public void pauseGame(InputAction.CallbackContext context)
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        battleMusic.instance.GetComponent<AudioSource>().Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        battleMusic.instance.GetComponent<AudioSource>().Pause();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    public void LoadMenu()
    {
        battleMusic.instance.GetComponent<AudioSource>().Stop();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        pauseMenuUI.SetActive(false);
        GameIsPaused=false;
        AudioManager.audioManagerInst.GetComponent<AudioSource>().Play();
        //Resume();
        Debug.Log("Loading Menu...");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
