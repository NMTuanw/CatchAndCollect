using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSlot : MonoBehaviour
{
    [Header("Reference")]
    public UpgradeSO upgradeSO;

    [Header("UI")]
    public TextMeshProUGUI upgradeName;
    public Image upgradeImage;
    public TextMeshProUGUI upgradeLevel;
    public TextMeshProUGUI upgradeDescription;
    public TextMeshProUGUI upgradePrice;

    void Start()
    {
        
    }
    void Update()
    {
        UpdateUpgradeSlotUI();
    }

    private void UpdateUpgradeSlotUI()
    {
        upgradeName.text = upgradeSO.upgradeName;
        upgradeImage.sprite = upgradeSO.upgradeIcon;
        upgradeDescription.text = upgradeSO.upgradeDescription;
        upgradePrice.text = upgradeSO.upgradePrice.ToString();
        
        upgradeLevel.text = "LV. " + upgradeSO.upgradeLevel.ToString() + " / " + upgradeSO.upgradeLevelCap;
        if (upgradeSO.upgradeLevel == upgradeSO.upgradeLevelCap)
        {
            upgradeLevel.text = "LV. MAX";
        }
    }
}
