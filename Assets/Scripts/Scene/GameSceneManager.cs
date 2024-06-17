using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public Button mainMenuButton;
    public Button levelSelectButton;
    void Start()
    {
        mainMenuButton.onClick.AddListener(() => { LoadGameScene("MainMenu"); });
        levelSelectButton.onClick.AddListener(() => { LoadGameScene("LevelSelect"); });
    }

    public void LoadGameScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
