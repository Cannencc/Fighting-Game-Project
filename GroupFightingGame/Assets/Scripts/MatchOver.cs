using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MatchOver : MonoBehaviour
{
    public GameObject MatchOverUI;

    // Different scene loads per map
    public void RematchTaiga()
    {
        SceneManager.LoadScene("Taiga Map");
        Time.timeScale = 1f;
        MatchOverUI.SetActive(false);
        PauseMenu.GameIsPaused = false;
    }

    public void RematchCave()
    {
        SceneManager.LoadScene("Cave Map");
        Time.timeScale = 1f;
        MatchOverUI.SetActive(false);
        PauseMenu.GameIsPaused = false;
    }

    public void RematchTraining()
    {
        SceneManager.LoadScene("TrainingLevel");
        Time.timeScale = 1f;
        MatchOverUI.SetActive(false);
        PauseMenu.GameIsPaused = false;
    }

    public void MapSelect()
    {
        Time.timeScale = 1f;
        MatchOverUI.SetActive(false);
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene("Map Select");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        MatchOverUI.SetActive(false);
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Loading Menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    // Update is called once per frame
    private void Update()
    {
        if(PlayerControllerTest.P1currentHealth <= 0 || PlayerControllerTest.P2currentHealth <= 0 || Countdown.currentT == 0)
        {
            Time.timeScale = 0f;
            MatchOverUI.SetActive(true);
            Countdown.currentT = 60f;
            PlayerControllerTest.P1currentHealth = 100;
            PlayerControllerTest.P2currentHealth = 100;
        }

    }
}
