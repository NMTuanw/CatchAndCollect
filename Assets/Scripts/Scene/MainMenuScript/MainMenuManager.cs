using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        playButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.TownScene);
        });

        exitButton.onClick.AddListener(() => {
            Application.Quit();
            Debug.Log("Quitting");
        });
    }
}
