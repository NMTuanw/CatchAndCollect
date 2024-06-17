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

    private void Update()
    {
        UpdateLevelSlotUI();
    }

    private void UpdateLevelSlotUI()
    {
        levelName.text = levelSO.levelName;
        levelBackground.sprite = levelSO.levelImage;
    }
}
