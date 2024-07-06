using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSceneLoading : MonoBehaviour
{
    public Button[] levelButton;
    private void Start()
    {
        for (int i = 0; i < levelButton.Length; i++)
        {
            int index = i;
            levelButton[i].onClick.AddListener(() =>
            {
                LoadScene("Level" + (index + 1));
            });
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
