using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade SO")]
public class UpgradeSO : ScriptableObject
{
    [Header("Item Stats (can change)")]
    public string upgradeName;
    public Sprite upgradeIcon;

    [Header("read-only")]
    public int upgradeLevel;
    public int upgradePrice;
    public int upgradeLevelCap;

    [TextArea]
    public string upgradeDescription;
}
