using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public CharacterStats characterStats;
    public UpgradeSO Health;
    public UpgradeSO Speed;
    public UpgradeSO DashSpeed;
    public UpgradeSO DashDuration;
    public UpgradeSO DashCooldown;

    [Header("Upgrade Value")]
    public int healthValue;
    public int speedValue;
    public int dashSpeedValue;
    public float dashDurationValue;
    public float dashCooldownValue;
    private void ApplyUpgrade(UpgradeSO upgradeSO)
    {
        switch (upgradeSO.upgradeName)
        {
            case "Health":
                characterStats.IncreaseHealth(healthValue); // assuming upgradeLevel represents the amount to increase
                upgradeSO.upgradeLevel += 1;
                break;
            case "Speed":
                characterStats.IncreaseMoveSpeed(speedValue);
                upgradeSO.upgradeLevel += 1;
                break;
            case "Dash Speed":
                characterStats.IncreaseDashSpeed(dashSpeedValue);
                upgradeSO.upgradeLevel += 1;
                break;
            case "Dash Duration":
                characterStats.IncreaseDashDuration(dashDurationValue);
                upgradeSO.upgradeLevel += 1;
                break;
            case "Dash Cooldown":
                characterStats.DecreaseDashCooldown(dashCooldownValue);
                upgradeSO.upgradeLevel += 1;
                break;
            default:
                Debug.LogWarning("Unknown upgrade type: " + upgradeSO.upgradeName);
                break;
        }

        characterStats.SaveStats();
    }

        public void UpgradeHealth()
        {
            ApplyUpgrade(Health); // Replace with logic to select correct UpgradeSO
        }

        public void UpgradeSpeed()
        {
            ApplyUpgrade(Speed); // Replace with logic to select correct UpgradeSO
        }

        public void UpgradeDashSpeed()
        {
            ApplyUpgrade(DashSpeed); // Replace with logic to select correct UpgradeSO
        }

        public void UpgradeDashDuration()
        {
            ApplyUpgrade(DashDuration); // Replace with logic to select correct UpgradeSO
        }

        public void UpgradeDashCooldown()
        {
            ApplyUpgrade(DashCooldown); // Replace with logic to select correct UpgradeSO
        }

    public void ResetCharacterStats()
    {
        characterStats.ResetStats();
        ResetUpgradeLevels();
    }

    private void ResetUpgradeLevels()
    {
        Health.upgradeLevel = 1;
        Speed.upgradeLevel = 1;
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
