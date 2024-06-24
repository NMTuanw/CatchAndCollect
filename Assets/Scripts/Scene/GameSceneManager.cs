using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public Button levelSelectButton;
    void Start()
    {
        levelSelectButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.LevelSelectScene);
        });
    }
}
