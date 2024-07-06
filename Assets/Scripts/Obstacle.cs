using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static event EventHandler OnObstacleCollect;

    [SerializeField] private int obstacleDamage;
    public ItemSO itemSO;
    public int collectedNumber;
    private void Start()
    {
        collectedNumber = PlayerPrefs.GetInt(itemSO.itemName + "collectedNumber", 0);
    }
    private void Update()
    {
        Drop();
    }
    public void Drop()
    {
        transform.Translate(Vector2.down * itemSO.droppingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {   
            Destroy(gameObject);
            collectedNumber += 1;
            PlayerPrefs.SetInt(itemSO.itemName + "collectedNumber", collectedNumber);
            HealthManager.Instance.RemoveHealth(obstacleDamage);
            OnObstacleCollect?.Invoke(this, EventArgs.Empty);

        }
    }
}
