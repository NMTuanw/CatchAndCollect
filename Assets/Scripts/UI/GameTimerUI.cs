using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerUI : MonoBehaviour
{
    private float countDownTime = 0f;
    public TextMeshProUGUI timerText;
    
    private void Update()
    {
        CountdownGameTimer();
    }

    private void CountdownGameTimer()
    {
        countDownTime = CatchGameManager.Instance.GetPlayingTimer();

        timerText.text =  "" + (int)countDownTime;
    }
}
