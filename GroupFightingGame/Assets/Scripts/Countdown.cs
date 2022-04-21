using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Countdown : MonoBehaviour
{
    public const float startingT = 60f;
    public static float currentT = 25f;

    [SerializeField] TextMeshProUGUI countdownText;
    void Start()
    {
        currentT = startingT;
    }

    void Update()
    {
        currentT -= 1 * Time.deltaTime;
        countdownText.text = currentT.ToString("0");
        if(currentT < 21)
        {
            countdownText.color = Color.red;
        }
        if(currentT <= 0)
        {
            currentT = 0f;
        }
    }
}
