using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI targetScoreText;
    [SerializeField] private TextMeshProUGUI yourScoreText;

    [Header("Stars")]
    [SerializeField] private GameObject firstStar;
    [SerializeField] private GameObject secondStar;
    [SerializeField] private GameObject thirdStar;

    [Header("Button")]
    [SerializeField] private Button levelSelectButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button retryButton;

    private void Start()
    {
        CatchGameManager.Instance.OnStateChanged += CatchGameManager_OnStateChanged;
        Hide();

        levelSelectButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.LevelSelectScene);
        });

        homeButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.TownScene);
        });

        retryButton.onClick.AddListener(() => {
            RestartGame();
        });
    }

    private void CatchGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (CatchGameManager.Instance.IsGameOver())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void Show(){
        gameObject.SetActive(true);
        Time.timeScale = 0f;

        Debug.Log("GameOVer UI");


        UpdateLevelStar();
        UpdateScore();
    }

    private void Hide(){
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    private void UpdateScore()
    {
        targetScoreText.text = ScoreManager.instance.thirdStarScore.ToString();
        yourScoreText.text = ScoreManager.instance.score.ToString();
    }

    private void UpdateLevelStar()
    {
        if (ScoreManager.instance.score >= ScoreManager.instance.firstStarScore)
        {
            firstStar.SetActive(true);
        }
        if (ScoreManager.instance.score >= ScoreManager.instance.secondStarScore)
        {
            secondStar.SetActive(true);
        }
        if (ScoreManager.instance.score >= ScoreManager.instance.thirdStarScore)
        {
            thirdStar.SetActive(true);
        }
    }
    public void RestartGame()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
