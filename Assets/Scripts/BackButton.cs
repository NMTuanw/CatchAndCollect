using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Button changeSceneButton; // Nút để chuyển scene
    void Start()
    {
        changeSceneButton.onClick.AddListener(() => {
            LoadGameScene("TownScene");
        });
    }

    private void LoadGameScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
