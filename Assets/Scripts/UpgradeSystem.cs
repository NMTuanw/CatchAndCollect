using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public CharacterStats characterStats;

    public void UpgradeHealth()
    {
        characterStats.IncreaseHealth(1);
        characterStats.SaveStats();
    }

    public void UpgradeSpeed()
    {
        characterStats.IncreaseMoveSpeed(5);
        characterStats.SaveStats();
    }

    public void UpgradeDashSpeed()
    {
        characterStats.IncreaseDashSpeed(5);
        characterStats.SaveStats();
    }

    public void UpgradeDashDuration()
    {
        characterStats.IncreaseDashDuration(5f);
        characterStats.SaveStats();
    }
    public void UpgradeDashCooldown()
    {
        characterStats.DecreaseDashCooldown(0.5f);
        characterStats.SaveStats();
    }
    public void ResetCharacterStats()
    {
        characterStats.ResetStats();
    }

    private void OnDisable()
    {
        characterStats.SaveStats();
    }

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        characterStats.LoadStats();
    }
}
