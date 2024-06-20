using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{
    public LevelSO levelSO;
    public void OnLevelComplete()
    {
        ScoreManager.instance.CheckScoreAndSaveStars(levelSO);

        if(LevelSelectManager2.currLevel == LevelSelectManager2.unlockedLevels)
        {
            LevelSelectManager2.unlockedLevels++;
            PlayerPrefs.SetInt("unlockedLevels", LevelSelectManager2.unlockedLevels);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene("LevelSelect Test");
    }
}
