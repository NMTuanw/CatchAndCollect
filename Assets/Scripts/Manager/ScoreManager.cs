using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private TextMeshProUGUI scoreText;

    public int firstStarScore;
    public int secondStarScore;
    public int thirdStarScore;

    public int score = 0;
    private int currentStars = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
    }

    public void CheckScoreAndSaveStars(LevelSO levelSO)
    {
        if(score >= thirdStarScore)
        {
            currentStars = 3;
        }
        else if(score >= secondStarScore)
        {
            currentStars = 2;
        }
        else if(score >= firstStarScore)
        {
            currentStars = 1;
        }
        else
        {
            currentStars = 0;
        }
        
        if (levelSO.levelStars <= currentStars) // neu so star lon hon thi khong cap nhat
        {
            levelSO.levelStars = currentStars;
        }

        PlayerPrefs.SetInt("Level" + levelSO.levelIndex + "Stars", levelSO.levelStars);
        PlayerPrefs.Save();
    }

    public int GetScore()
    {
        return score;
    }
}
