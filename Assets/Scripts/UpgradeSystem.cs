using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class UpgradeSystem : MonoBehaviour
{
    public delegate void CharacterStatUpgradeMethodInt(int value);
    public delegate void CharacterStatUpgradeMethodFloat(float value);

    [Header("Reference")]
    public CharacterStats characterStats;
    public UpgradeSO Health;
    public UpgradeSO MoveSpeed;
    public UpgradeSO DashSpeed;
    public UpgradeSO DashDuration;
    public UpgradeSO DashCooldown;

    [Header("Upgrade Value")]
    public int healthValue;
    public int moveSpeedValue;
    public int dashSpeedValue;
    public float dashDurationValue;
    public float dashCooldownValue;

    private void Awake()
    {
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        characterStats.LoadStats();

        LoadUpgradeLevels();
    }
    
    
    private void ApplyUpgrade(UpgradeSO upgradeSO)
    {
        switch (upgradeSO.upgradeName)
        {
            case "Health":
                UpgradeLevelAndStatInt(Health, characterStats.IncreaseHealth, healthValue);
                break;
            case "Move Speed":
                UpgradeLevelAndStatInt(MoveSpeed, characterStats.IncreaseMoveSpeed, moveSpeedValue);
                break;
            case "Dash Speed":
                UpgradeLevelAndStatInt(DashSpeed, characterStats.IncreaseDashSpeed, dashSpeedValue);
                break;
            case "Dash Duration":
                UpgradeLevelAndStatFloat(DashDuration, characterStats.IncreaseDashDuration, dashDurationValue);
                break;
            case "Dash Cooldown":
                UpgradeLevelAndStatFloat(DashCooldown, characterStats.DecreaseDashCooldown, dashCooldownValue);
                break;
            default:
                Debug.LogWarning("Unknown upgrade type: " + upgradeSO.upgradeName);
                break;
            
        }
        
        SaveUpgradeLevels();
        characterStats.SaveStats();
    }

    private void UpgradeLevelAndStatInt(UpgradeSO upgradeSO, CharacterStatUpgradeMethodInt upgradeMethod, int upgradeValue)
    {
        if (CoinManager.instance.coin >= upgradeSO.upgradePrice && upgradeSO.upgradeLevel < upgradeSO.upgradeLevelCap)
        {
            upgradeMethod(upgradeValue); 
            upgradeSO.upgradeLevel += 1;
            CoinManager.instance.SpendCoins(upgradeSO.upgradePrice);
        } else {
            return;
        }       
    }

    private void UpgradeLevelAndStatFloat(UpgradeSO upgradeSO, CharacterStatUpgradeMethodFloat upgradeMethod, float upgradeValue)
    {
        if (CoinManager.instance.coin >= upgradeSO.upgradePrice && upgradeSO.upgradeLevel < upgradeSO.upgradeLevelCap)
        {
            upgradeMethod(upgradeValue); 
            upgradeSO.upgradeLevel += 1;
            CoinManager.instance.SpendCoins(upgradeSO.upgradePrice);
        } else {
            return;
        }       
    }

    // UpgradeManager -> UI Button
        public void UpgradeHealth()
        {
            ApplyUpgrade(Health);
        }

        public void UpgradeSpeed()
        {
            ApplyUpgrade(MoveSpeed);
        }

        public void UpgradeDashSpeed()
        {
            ApplyUpgrade(DashSpeed);
        }

        public void UpgradeDashDuration()
        {
            ApplyUpgrade(DashDuration);
        }

        public void UpgradeDashCooldown()
        {
            ApplyUpgrade(DashCooldown);
        }

    public void ResetCharacterStats()
    {
        characterStats.ResetStats();
        ResetUpgradeLevels();
        CoinManager.instance.ResetCoins();
    }

    private void ResetUpgradeLevels()
    {
        Health.upgradeLevel = 1;
        MoveSpeed.upgradeLevel = 1;
        DashSpeed.upgradeLevel = 1;
        DashDuration.upgradeLevel = 1;
        DashCooldown.upgradeLevel = 1;
        SaveUpgradeLevels();
    }

    private void OnDisable()
    {
        characterStats.SaveStats();
    }

    private void SaveUpgradeLevels()
    {
        PlayerPrefs.SetInt(Health.upgradeName + "Level", Health.upgradeLevel);
        PlayerPrefs.SetInt(MoveSpeed.upgradeName + "Level", MoveSpeed.upgradeLevel);
        PlayerPrefs.SetInt(DashSpeed.upgradeName + "Level", DashSpeed.upgradeLevel);
        PlayerPrefs.SetInt(DashDuration.upgradeName + "Level", DashDuration.upgradeLevel);
        PlayerPrefs.SetInt(DashCooldown.upgradeName + "Level", DashCooldown.upgradeLevel);
        PlayerPrefs.Save();
    }
    
    private void LoadUpgradeLevels()
    {
        Health.upgradeLevel = PlayerPrefs.GetInt(Health.upgradeName + "Level", 1);
        MoveSpeed.upgradeLevel = PlayerPrefs.GetInt(MoveSpeed.upgradeName + "Level", 1);
        DashSpeed.upgradeLevel = PlayerPrefs.GetInt(DashSpeed.upgradeName + "Level", 1);
        DashDuration.upgradeLevel = PlayerPrefs.GetInt(DashDuration.upgradeName + "Level", 1);
        DashCooldown.upgradeLevel = PlayerPrefs.GetInt(DashCooldown.upgradeName + "Level", 1);
    }
}
