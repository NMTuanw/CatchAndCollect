using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LevelCompleteScript : MonoBehaviour
{
    public LevelSO levelSO;

    public void OnLevelComplete()
    {
        ScoreManager.instance.CheckScoreAndSaveStars(levelSO);

        SaveHighScore();
        UnlockNextLevel();
    }

    private void SaveHighScore()
    {
        if (ScoreManager.instance.score > levelSO.highScore)
        {
            levelSO.highScore = ScoreManager.instance.score;
        }
    }

    private void UnlockNextLevel()
    {
        if(levelSO.levelStars >= 2) 
        {
            int unlockedLevels = LevelSelectManager.unlockedLevels;

            if(levelSO.levelIndex == unlockedLevels)
            {
                unlockedLevels++; 
                PlayerPrefs.SetInt("unlockedLevels", unlockedLevels);
                PlayerPrefs.Save();
            }
        }
    }
}
