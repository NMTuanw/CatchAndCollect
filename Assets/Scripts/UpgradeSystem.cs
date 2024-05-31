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
    }

    private void OnDisable()
    {
        characterStats.SaveStats();
    }

    private void Awake()
    {
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        characterStats.LoadStats();
    }
}
