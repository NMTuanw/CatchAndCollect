using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public HealthUI healthUI;
    public PlayerMovement playerMovement;

    void Awake()
    {
        healthUI = GameObject.Find("HealthUI").GetComponent<HealthUI>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
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
        }
    }

    private void Die()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
           //Destroy(player);
        }
        Debug.Log("Player die");
    }
}
