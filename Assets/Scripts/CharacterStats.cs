using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Default Stats When Reset")]
    public int defaultHealth;
    public int defaultMoveSpeed;
    public int defaultDashSpeed;
    public float defaultDashDuration;
    public float defaultDashCooldown;

    public int health;
    public int moveSpeed;
    public int dashSpeed;
    public float dashDuration;
    public float dashCooldown;

    public void IncreaseHealth(int amount)
    {
        health += amount;
    }

    public void IncreaseMoveSpeed(int amount)
    {
        moveSpeed += amount;
    }

    public void IncreaseDashSpeed(int amount)
    {
        dashSpeed += amount;
    }

    public void IncreaseDashDuration(float amount)
    {
        dashDuration += amount;
    }

    public void DecreaseDashCooldown(float amount)
    {
        dashCooldown -= amount;
    }
    private void Awake()
    {
        LoadStats();
    }
    void Start()
    {
        LoadStats();
    }

    public void SaveStats()
    {
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetInt("moveSpeed", moveSpeed);
        PlayerPrefs.SetInt("dashSpeed", dashSpeed);
        PlayerPrefs.SetFloat("dashDuration", dashDuration);
        PlayerPrefs.SetFloat("dashCooldown", dashCooldown);
        PlayerPrefs.Save();
    }

    public void LoadStats()
    {
        health = PlayerPrefs.GetInt("health", health);
        moveSpeed = PlayerPrefs.GetInt("moveSpeed", moveSpeed);
        dashSpeed = PlayerPrefs.GetInt("dashSpeed", dashSpeed);
        dashDuration = PlayerPrefs.GetFloat("dashDuration", dashDuration);
        dashCooldown = PlayerPrefs.GetFloat("dashCooldown", dashCooldown);
    }

    public void ResetStats()
    {
        health = defaultHealth;
        moveSpeed = defaultMoveSpeed;
        dashSpeed = defaultDashSpeed;
        dashDuration = defaultDashDuration;
        dashCooldown = defaultDashCooldown;

        SaveStats();
    }
}
