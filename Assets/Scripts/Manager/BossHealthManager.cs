using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{
    public static BossHealthManager instance;

    public GameObject boss;
    public BossSO bossSO;

    public int health;

    private void Awake()
    {
        boss = GameObject.FindWithTag("Boss");

        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        health = bossSO.bossHealth;
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
        if (boss != null)
        {
            Destroy(boss);
            //GameManager.Instance.GameOver();
        }
        Debug.Log("Player die");
    }

}
