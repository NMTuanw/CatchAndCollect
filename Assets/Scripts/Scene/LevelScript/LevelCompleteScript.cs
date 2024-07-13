using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelCompleteScript : MonoBehaviour
{
    public LevelSO currentlevelSO;
    public int currentLevelIndex;
    private int highScore = 0;
    private int currentStars = 0;
    public void OnLevelComplete()
    {
        ScoreManager.instance.CheckScoreAndSaveStars(currentlevelSO);
        SaveHighScore();
        SaveStars();
        UnlockNextLevel();
    }

    private void SaveHighScore()
    {
        highScore = PlayerPrefs.GetInt("highScore" + currentlevelSO.levelIndex, ScoreManager.instance.score);

        if (ScoreManager.instance.score > highScore)
        {
            PlayerPrefs.SetInt("highScore" + currentlevelSO.levelIndex, ScoreManager.instance.score);
        }
    }

    private void SaveStars()
    {
        currentStars = PlayerPrefs.GetInt("Level" + currentlevelSO.levelIndex + "Stars", ScoreManager.instance.currentStars);

        if (ScoreManager.instance.currentStars > currentStars)
        {

            PlayerPrefs.SetInt("Level" + currentlevelSO.levelIndex + "Stars", ScoreManager.instance.currentStars);
        }
    }
    private void UnlockNextLevel()
    {
        if (ScoreManager.instance.currentStars >= 2)
        {
            int unlockedLevels = LevelSelectManager.unlockedLevels;

            if (currentlevelSO.levelIndex == unlockedLevels)
            {
                unlockedLevels++;
                PlayerPrefs.SetInt("unlockedLevels", unlockedLevels);
                PlayerPrefs.Save();
            }
        }
    }
}
