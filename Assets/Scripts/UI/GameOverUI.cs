using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    void Awake()
    {
        gameOverUI = GameObject.Find("GameOverUI");
        
        Hide();
    }

    private void Update()
    {
        restartButton.onClick.AddListener(() => {
            //RestartGame();
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            // return to town scene
            //GoToTown();
        });
    }

    public void Show(){
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("GameOVer UI");
    }

    private void Hide(){
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
