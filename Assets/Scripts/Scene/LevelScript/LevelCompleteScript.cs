using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LevelCompleteScript : MonoBehaviour
{
    public LevelSO currentlevelSO;

    public void OnLevelComplete()
    {
        ScoreManager.instance.CheckScoreAndSaveStars(currentlevelSO);

        SaveHighScore();
        UnlockNextLevel();
    }

    private void SaveHighScore()
    {
        if (ScoreManager.instance.score > currentlevelSO.highScore)
        {
            currentlevelSO.highScore = ScoreManager.instance.score;
        }
    }

    private void UnlockNextLevel()
    {
        if(currentlevelSO.levelStars >= 2) 
        {
            int unlockedLevels = LevelSelectManager.unlockedLevels;

            if(currentlevelSO.levelIndex == unlockedLevels)
            {
                unlockedLevels++; 
                PlayerPrefs.SetInt("unlockedLevels", unlockedLevels);
                PlayerPrefs.Save();
            }
        }
    }
}
