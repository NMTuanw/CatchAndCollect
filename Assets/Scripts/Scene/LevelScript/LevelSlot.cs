using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlot : MonoBehaviour
{
    [SerializeField] private LevelSO levelSO;
    [SerializeField] private TextMeshProUGUI levelName;
    [SerializeField] private TextMeshProUGUI levelHighScore;
    [SerializeField] private Image levelBackground;

    [SerializeField] private GameObject firstStar;
    [SerializeField] private GameObject secondStar;
    [SerializeField] private GameObject thirdStar;

    [SerializeField] private GameObject levelLockImage;
    public Button levelButton;

    public int currentLevelIndex;
    private int highScore;
    private int currentStars;
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore" + levelSO.levelIndex, 0);
        currentStars = PlayerPrefs.GetInt("Level" + levelSO.levelIndex + "Stars", 0);
    }
    private void Update()
    {
        UpdateLevelSlotUI();
        UpdateLevelSlotStar();
        UnlockLevelButton();
    }

    private void UpdateLevelSlotUI()
    {
        levelName.text = levelSO.levelName;
        levelBackground.sprite = levelSO.levelImage;
        levelHighScore.text = highScore.ToString();
    }

    private void UpdateLevelSlotStar()
    {
        firstStar.SetActive(currentStars >= 1);
        secondStar.SetActive(currentStars >= 2);
        thirdStar.SetActive(currentStars >= 3);
    }

    private void UnlockLevelButton()
    {
        if (levelButton.interactable == true)
        {
            levelLockImage.SetActive(false);
        } else {
            levelLockImage.SetActive(true);
        }
    }

    public void ResetStat()
    {
        currentStars = 0;
        highScore = 0;

        PlayerPrefs.SetInt("highScore" + levelSO.levelIndex, highScore);

        PlayerPrefs.SetInt("Level" + levelSO.levelIndex + "Stars", currentStars);
    }
}
