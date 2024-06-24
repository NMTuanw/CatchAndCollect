using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }

    public CharacterStats characterStats;
    public GameObject player;

    public int health;
    public Image healthBar;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();

        // Singleton pattern
        Instance = this;
    }
    void Start()
    {
        health = characterStats.health;
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount =  (float)health / (float)characterStats.health;
        }
    }

    public void AddHealth(int value)
    {
        health += value;
        UpdateHealthBar();
        
    }

    public void RemoveHealth(int value)
    {
        health -= value;
        if (health <= 0)
        {
            health = 0;
            Die();
        } 
        UpdateHealthBar();
    }

    private void Die()
    {
        if (player != null)
        {
            Destroy(player);
        }
    }

}
