using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [Header("Add more Level Here")]
    [SerializeField] private Button[] levelButtons;

    [Header("Switch Page UI")]
    [SerializeField] private GameObject[] levelPages;
    [SerializeField] private Button backArrowButton;
    [SerializeField] private Button nextArrowButton;

    private int currentPageIndex = 0;
    private void Start()
    {
        for(int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;
            levelButtons[i].onClick.AddListener(() => LoadScene("Level" + levelIndex));
        }

        UpdatePage();
        nextArrowButton.onClick.AddListener(OnNextPage);
        backArrowButton.onClick.AddListener(OnBackPage);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void UpdatePage()
    {
        for (int i = 0; i < levelPages.Length; i++)
        {
            levelPages[i].SetActive(false);
        }

        if (currentPageIndex >= 0 && currentPageIndex < levelPages.Length)
        {
            levelPages[currentPageIndex].SetActive(true);
        }

        backArrowButton.interactable = currentPageIndex > 0;
        nextArrowButton.interactable = currentPageIndex < levelPages.Length - 1;
    }

    private void OnNextPage()
    {
        if (currentPageIndex < levelPages.Length - 1)
        {
            currentPageIndex++;
            UpdatePage();
        }
    }

    private void OnBackPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            UpdatePage();
        }
    }

}
