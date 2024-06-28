using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchGameManager : MonoBehaviour
{
    public static CatchGameManager Instance {get; private set;}

    public event EventHandler OnStateChanged;
    public event EventHandler OnGameOptionOpen;
    public event EventHandler OnGameOptionClose;
    public event EventHandler OnGameOver;
    private enum State {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }
    private State state;
    [SerializeField] private float countdownToStartTimer;
    [SerializeField] public float gamePlayingTimer;
    [SerializeField] private float gamePlayingTimerMax;

    private bool IsGamePause = false;
    private void Awake() {
        Instance = this;

        state = State.CountdownToStart; 
    }

    private void OptionsUI_OnOptionClick(object sender, EventArgs e)
    {
        TogglePauseGame();
    }

    private void Update() {
        switch (state) {
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer <= 0f) {
                    state = State.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer <= 0f || HealthManager.Instance.health <= 0f) {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.GameOver:
                break;
        }
        Debug.Log(state);
    }
    public bool IsGamePlaying() {
        return state == State.GamePlaying;
    }

    public bool IsCountdownToStartActive() {
        return state == State.CountdownToStart;
    }

    public float GetCountdownToStartTimer() {
        return countdownToStartTimer;
    }

    public bool IsGameOver() {
        return state == State.GameOver;
    }

    public float GetPlayingTimer()
    {
        return gamePlayingTimer;
    }
    public float GetPlayingTimerNormalized() {
        return 1 - (gamePlayingTimer / gamePlayingTimerMax);
    }

    public void TogglePauseGame() {
        IsGamePause = !IsGamePause;
        if (IsGamePause) {
            Time.timeScale = 0f;
            OnGameOptionOpen?.Invoke(this, EventArgs.Empty);
        } else {
            Time.timeScale = 1f;
            OnGameOptionClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
