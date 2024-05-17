using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public HealthUI healthUI;
    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        healthUI = GameObject.Find("HealthUI").GetComponent<HealthUI>();

        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void AddHealth(int value)
    {
        healthUI.health += value;
    }

    public void RemoveHealth(int value)
    {
        healthUI.health -= value;
        if (healthUI.health <= 0)
        {
            Die();
            GameManager.Instance.GameOver();
        }
    }

    private void Die()
    {
        if (player != null)
        {
           Destroy(player);
        }
        Debug.Log("Player die");
    }
}
