using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public float countDownTime;
    public TextMeshProUGUI timerText;
    public Image fill;

    public float Max;

    private void Start()
    {
        
    }

    private void Update()
    {
        countDownTime -= Time.deltaTime;
        timerText.text =  "" + (int)countDownTime;
        fill.fillAmount = countDownTime / Max;

        if (countDownTime < 0)
        {
            countDownTime = 0;
            // Chay UI het thoi gian
        }
    }


}
