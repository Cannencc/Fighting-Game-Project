using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RoundTimer : MonoBehaviour
{
    public static float currentRound = 1f;
    public static float roundCount = 1f;

    [SerializeField] TextMeshProUGUI roundNum;
    [SerializeField] TextMeshProUGUI roundText;
    [SerializeField] TextMeshProUGUI fightText;
    public Image P1_R1_OFF;
    public Image P1_R2_OFF;
    public Image P2_R1_OFF;
    public Image P2_R2_OFF;
    public Image P1_R1_ON;
    public Image P1_R2_ON;
    public Image P2_R1_ON;
    public Image P2_R2_ON;
    public static int P1_WIN = 0;
    public static int P2_WIN = 0;

    void Start()
    {
        roundText.enabled = true;
        roundNum.enabled = true;
        Destroy(roundText, 1);
        Destroy(roundNum, 1);
        fightText.enabled = false;
        StartCoroutine(Delay());

        P1_R1_ON.enabled = false;
        P1_R2_ON.enabled = false;
        P2_R1_ON.enabled = false;
        P2_R2_ON.enabled = false;

        if (P1_WIN >= 1)
            P1_R1_ON.enabled = true;

        if (P1_WIN >= 2)
            P1_R2_ON.enabled = true;

        if (P2_WIN >= 1)
            P2_R1_ON.enabled = true;

        if (P2_WIN >= 2)
            P2_R2_ON.enabled = true;
    }

    void Update()
    {
        roundNum.text = currentRound.ToString("0");
        if (PlayerControllerTest.P1currentHealth <= 0 || PlayerControllerTest.P2currentHealth <= 0 || Countdown.currentT == 0)
        {
            if (PlayerControllerTest.P1currentHealth <= 0)
            {
                P2_WIN++;
            }

            if (PlayerControllerTest.P2currentHealth <= 0)
            {
                P1_WIN++;
            }

            currentRound += 1f;
            roundCount += 1f;
            Time.timeScale = 1f;

            if (SceneManager.GetActiveScene().buildIndex == 3)
                SceneManager.LoadScene("Taiga Map");

            else if (SceneManager.GetActiveScene().buildIndex == 4)
                SceneManager.LoadScene("Cave Map");

            else if (SceneManager.GetActiveScene().buildIndex == 5)
                SceneManager.LoadScene("TrainingLevel1");
        }

        if (roundCount >= 4 || P1_WIN >= 2 || P2_WIN >= 2 || MatchOver.MatchOverFlag == 1)
        {
            roundText.enabled = false;
            roundNum.enabled = false;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        fightText.enabled = true;
        Destroy(fightText, 1);
    }
}
