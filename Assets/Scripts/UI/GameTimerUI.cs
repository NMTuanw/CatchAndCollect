using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerUI : MonoBehaviour
{
    public float countDownTime;
    public TextMeshProUGUI timerText;
    public Image fill;
    public float Max;
    private bool gameStarted;
    
    private void Awake()
    {
        GameStartCoundownUI.GameStartCountdownFinished += GameStartCoundownUI_GameStartCountdownFinished; ;
    }

    private void GameStartCoundownUI_GameStartCountdownFinished()
    {
        gameStarted = true;
    }

    private void Update()
    {
        if (gameStarted)
        {
            CountdownGameTimer();
        }
    }

    private void CountdownGameTimer()
    {
        countDownTime -= Time.deltaTime;
        timerText.text =  "" + (int)countDownTime;
        fill.fillAmount = countDownTime / Max;

        if (countDownTime < 0)
        {
            countDownTime = 0;
            // GameOver
        }
    }
}
