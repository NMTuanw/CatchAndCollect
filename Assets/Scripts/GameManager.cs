using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public event EventHandler OnGameOptionOpen;
    public event EventHandler OnGameOptionClose;

    [SerializeField] private float countdownToStartTimer = 3f;
    [SerializeField] private float gameTimer;
    [SerializeField] private float gameTimerMax = 60f;

    private bool isGamePaused;
    private void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {

    }

    public void PauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0;
            OnGameOptionOpen?.Invoke(this, EventArgs.Empty);
        } else
        {
            Time.timeScale = 1f;
            OnGameOptionClose?.Invoke(this, EventArgs.Empty);
        }
    }

    public void GameOver()
    {
        
    }
}
