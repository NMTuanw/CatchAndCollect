using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int firstStarScore;
    public int secondStarScore;
    public int thirdStarScore;

    public int score = 0;
    public int currentStars = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        score = 0;
        currentStars = 0;
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

        //PlayerPrefs.SetInt("Level" + levelSO.levelIndex + "Stars", currentStars);
        //PlayerPrefs.Save();
    }

}
