using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static event EventHandler OnObstacleCollect;
    public ItemSO itemSO;
    [SerializeField] private int obstacleDamage;

    private void Update() {
        transform.Translate(Vector2.down * itemSO.droppingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Debug.Log("Prob touched the ground.");
        }

        if (other.gameObject.CompareTag("Player"))
        {   
            Destroy(gameObject);
            itemSO.collectedNumber += 1;
            HealthManager.Instance.RemoveHealth(obstacleDamage);
            Debug.Log("Obstacle touched the player.");
            OnObstacleCollect?.Invoke(this, EventArgs.Empty);

        }
    }
}
