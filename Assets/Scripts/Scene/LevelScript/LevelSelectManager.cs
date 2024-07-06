using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    public LevelSlot[] levelSlots;

    [Header("Switch Page UI")]
    [SerializeField] private Button backArrowButton;
    [SerializeField] private Button nextArrowButton;
    [SerializeField] private GameObject[] levelPages;
    
    public static int unlockedLevels;
    public static int currLevel;
    private int currentPageIndex = 0;

    void Start()
    {
        UpdatePage();
        nextArrowButton.onClick.AddListener(OnNextPage);
        backArrowButton.onClick.AddListener(OnBackPage);
    }

    void Update()
    {
        UnlockLevelButton();
    }
    
    private void UnlockLevelButton() 
    {
        int levelIndex = 0;
        unlockedLevels = PlayerPrefs.GetInt("unlockedLevels", levelIndex);  // unlockedlevels lấy giá trị của levelIndex

        if (unlockedLevels == 0)
        {
            unlockedLevels = 1;
            PlayerPrefs.SetInt("unlockedLevels", unlockedLevels);
            PlayerPrefs.Save();
        }

        Debug.Log(unlockedLevels);
        
        for (int i = 0; i < levelSlots.Length; i++) 
        {
            if (unlockedLevels > i) 
            {
                Debug.Log(unlockedLevels);
                levelSlots[i].levelButton.interactable = true;
            }
        }
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResetLevel()
    {
        for (int i = 0; i < levelSlots.Length; i++) 
        {
            levelSlots[i].levelButton.interactable = false;
            levelSlots[i].ResetStat();
        }
        PlayerPrefs.SetInt("unlockedLevels", 0);
        PlayerPrefs.Save();
    }

    // Switch Page Script
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
