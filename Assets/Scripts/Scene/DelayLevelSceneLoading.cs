using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DelayLevelSceneLoading : MonoBehaviour
{
    public Button level1;

    public Button[] levelButton;
    private void Start()
    {
        level1.onClick.AddListener(() =>
        {
            DelayLoading(0.2f, "Level1");
        });

        for (int i = 0; i < levelButton.Length; i++)
        {
            int index = i;
            levelButton[i].onClick.AddListener(() =>
            {
                DelayLoading(0.2f, "Level" + (index + 1));
            });
        }
    }

    public void DelayLoading(float seconds, string sceneName)
    {
        StartCoroutine(DelayedSceneLoad(seconds, sceneName));
    }

    private IEnumerator DelayedSceneLoad(float seconds, string sceneName)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);
    }

}
