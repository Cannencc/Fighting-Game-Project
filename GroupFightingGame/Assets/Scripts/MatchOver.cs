
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MatchOver : MonoBehaviour
{
    public GameObject MatchOverUI;
    public static int MatchOverFlag = 0;

    // Different scene loads per map
    public void RematchTaiga()
    {
        SceneManager.LoadScene("Taiga Map");
        battleMusic.instance.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        MatchOverUI.SetActive(false);
        PauseMenu.GameIsPaused = false;
    }

    public void RematchCave()
    {
        SceneManager.LoadScene("Cave Map");
        battleMusic.instance.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        MatchOverUI.SetActive(false);
        PauseMenu.GameIsPaused = false;
    }

    public void RematchTraining()
    {
        SceneManager.LoadScene("TrainingLevel1");
        battleMusic.instance.GetComponent<AudioSource>().Play();
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
        AudioManager.audioManagerInst.GetComponent<AudioSource>().Play();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        MatchOverUI.SetActive(false);
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene("Main Menu");
        AudioManager.audioManagerInst.GetComponent<AudioSource>().Play();
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
        if (RoundTimer.roundCount >= 4 || RoundTimer.P1_WIN >= 2 || RoundTimer.P2_WIN >= 2)
        {
            battleMusic.instance.GetComponent<AudioSource>().Stop();
            SoundManagerScript.PlaySound("roundEnd");
            Time.timeScale = 0f;
            MatchOverUI.SetActive(true);
            Countdown.currentT = 60f;
            PlayerControllerTest.P1currentHealth = 100;
            PlayerControllerTest.P2currentHealth = 100;
            RoundTimer.currentRound = 1f;
            RoundTimer.roundCount = 1f;
            RoundTimer.P1_WIN = 0;
            RoundTimer.P2_WIN = 0;
            MatchOverFlag = 1;
        }

    }
}