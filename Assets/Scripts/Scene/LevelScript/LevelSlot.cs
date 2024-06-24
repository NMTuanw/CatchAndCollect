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
        levelHighScore.text = levelSO.highScore.ToString();
    }

    private void UpdateLevelSlotStar()
    {
        firstStar.SetActive(levelSO.levelStars >= 1);
        secondStar.SetActive(levelSO.levelStars >= 2);
        thirdStar.SetActive(levelSO.levelStars >= 3);
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
        levelSO.levelStars = 0;
        levelSO.highScore = 0;
    }
}
