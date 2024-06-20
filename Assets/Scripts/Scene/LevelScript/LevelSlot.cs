using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlot : MonoBehaviour
{
    [SerializeField] private LevelSO levelSO;
    [SerializeField] private TextMeshProUGUI levelName;
    [SerializeField] private Image levelBackground;

    [SerializeField] private GameObject firstStar;
    [SerializeField] private GameObject secondStar;
    [SerializeField] private GameObject thirdStar;

    private void Update()
    {
        UpdateLevelSlotUI();
        UpdateLevelSlotStar();
    }

    private void UpdateLevelSlotUI()
    {
        levelName.text = levelSO.levelName;
        levelBackground.sprite = levelSO.levelImage;
    }

    private void UpdateLevelSlotStar()
    {
        firstStar.SetActive(levelSO.levelStars >= 1);
        secondStar.SetActive(levelSO.levelStars >= 2);
        thirdStar.SetActive(levelSO.levelStars >= 3);
    }
}
