using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCoundownUI : MonoBehaviour
{
    public static event Action GameStartCountdownFinished;
    [SerializeField] private GameObject TimerCountdownToStartUI;
    [SerializeField] private TextMeshProUGUI timerCountdownToStartText;
    
    [SerializeField] private float timerCountdownToStart;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }
    IEnumerator StartCountdown()
    {
        timerCountdownToStartText.text = timerCountdownToStart.ToString();

        yield return new WaitForSeconds(1f);

        while (timerCountdownToStart > 1)
        {
            timerCountdownToStart--;

            timerCountdownToStartText.text = timerCountdownToStart.ToString();

            yield return new WaitForSeconds(1f);
        }


        Hide();

        GameStartCountdownFinished?.Invoke();
    }
    private void Show(){
        TimerCountdownToStartUI.SetActive(true);
    }

    private void Hide(){
        TimerCountdownToStartUI.SetActive(false);
    }
}
