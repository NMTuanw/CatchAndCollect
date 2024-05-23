using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public CharacterStats characterStats;
    public GameObject player;

    public int health;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();

        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        health = characterStats.health;
    }
    
    public void AddHealth(int value)
    {
        health += value;
    }

    public void RemoveHealth(int value)
    {
        health -= value;
        if (health <= 0)
        {
            health = 0;
            Die();
        } 
    }

    private void Die()
    {
        if (player != null)
        {
            Destroy(player);
            //GameManager.Instance.GameOver();
        }
        Debug.Log("Player die");
    }

}
