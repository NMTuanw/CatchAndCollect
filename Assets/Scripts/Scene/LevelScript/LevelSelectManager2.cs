using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager2 : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;

    public LevelObject[] levelObjects;
    public static int unlockedLevels;
    public static int currLevel;

    void Start()
    {
        UnlockLevelButton();
    }

    void Update()
    {
        UnlockLevelButton();
    }
    private void UnlockLevelButton()
    {
        int levelIndex = 0;

        unlockedLevels = PlayerPrefs.GetInt("unlockedLevels", levelIndex); 
        
        for (int i = 0; i < levelObjects.Length; i++)
        {
            if (unlockedLevels >= i)
            {
                levelObjects[i].levelButton.interactable = true;
                // int stars = PlayerPrefs.GetInt("stars" + i.ToString(), 0);
                // for (int j = 0; j < stars; j++)
                // {
                //     levelObjects[j].stars[j].sprite = goldenstar;
                // }
            }
        }
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnClickBack()
    {
        this.gameObject.SetActive(false);
    }

}
