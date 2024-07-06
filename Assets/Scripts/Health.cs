using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event EventHandler OnHealthCollect;
    
    [SerializeField] private int healthValue;
    public ItemSO itemSO;
    private int collectedNumber;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collectedNumber += 1;
            PlayerPrefs.SetInt(itemSO.itemName + "collectedNumber", collectedNumber);
            HealthManager.Instance.AddHealth(healthValue);
            OnHealthCollect?.Invoke(this, EventArgs.Empty);

        }
    }
}
