using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            StartCoroutine(DelaySceneLoad());
        });

        exitButton.onClick.AddListener(() => {
            Application.Quit();
            Debug.Log("Quitting");
        });
    }


    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(0.3f);
        Loader.Load(Loader.Scene.TownScene);
    }
}
