using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }    
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        
    }
}
