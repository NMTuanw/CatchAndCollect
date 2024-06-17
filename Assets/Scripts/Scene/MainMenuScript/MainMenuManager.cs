using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        playButton.onClick.AddListener(() => {
            LoadScene("TownScene");
        });
        settingsButton.onClick.AddListener(() => {
            //LoadGameScene("Volume");
            Debug.Log("Settings UI");
        });
        exitButton.onClick.AddListener(() => {
            Application.Quit();
            Debug.Log("Quitting");
        });
    }

    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
