using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCoundownUI : MonoBehaviour
{
    //public event EventHandler GameStartCountdownFinished;

    //public event EventHandler OnStateChanged;

    //[SerializeField] private GameObject TimerCountdownToStartUI;
    //[SerializeField] private TextMeshProUGUI timerCountdownToStartText;

    //[SerializeField] private float timerCountdownToStart;
    //private enum State
    //{
    //    WaitingToStart,
    //    CountdownToStart,
    //    GamePlaying,
    //    GameOver,
    //}
    //private State state;

    //private void Start()
    //{
    //    StartCoroutine(StartCountdown());
    //    Show();
    //}

    //IEnumerator StartCountdown()
    //{
    //    timerCountdownToStartText.text = timerCountdownToStart.ToString();

    //    yield return new WaitForSeconds(1f);

    //    while (timerCountdownToStart > 1)
    //    {
    //        timerCountdownToStart--;

    //        timerCountdownToStartText.text = timerCountdownToStart.ToString();

    //        yield return new WaitForSeconds(1f);
    //    }


    //    Hide();

    //    GameStartCountdownFinished?.Invoke(this, EventArgs.Empty);
    //}
    //private void Show(){
    //    TimerCountdownToStartUI.SetActive(true);
    //}

    //private void Hide(){
    //    TimerCountdownToStartUI.SetActive(false);
    //}
    private const string NUMBER_POPUP = "NumberPopup";
    [SerializeField] private TextMeshProUGUI countdownText;

    //private Animator animator;
    private int previousCountdownNumber;
    private void Awake()
    {
        //animator = GetComponent<Animator>();
    }
    private void Start()
    {
        CatchGameManager.Instance.OnStateChanged += CatchGameManager_OnStateChanged;
    }

    private void Update()
    {
        int countdownNumber = Mathf.CeilToInt(CatchGameManager.Instance.GetCountdownToStartTimer());
        countdownText.text = countdownNumber.ToString();

        if (previousCountdownNumber != countdownNumber)
        {
            previousCountdownNumber = countdownNumber;
            //animator.SetTrigger(NUMBER_POPUP);
            //SoundManager.Instance.PlayCountdownNumber();
        }
    }
    private void CatchGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (CatchGameManager.Instance.IsCountdownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
