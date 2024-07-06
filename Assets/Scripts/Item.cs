using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static event EventHandler OnItemCollect;
    public ItemSO itemSO;
    private int collectedNumber;

    private void Start()
    {
        collectedNumber = PlayerPrefs.GetInt(itemSO.itemName + "collectedNumber", 0);
    }
    private void Update() {
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
            Debug.Log("Prob touched the ground.");
        }

        if (other.gameObject.CompareTag("Player"))
        {   
            Destroy(gameObject);
            collectedNumber += 1;
            PlayerPrefs.SetInt(itemSO.itemName + "collectedNumber", collectedNumber);
            ScoreManager.instance.AddScore(itemSO.gameScore);
            Debug.Log("Prob touched the player.");

            OnItemCollect?.Invoke(this, EventArgs.Empty);
        }
    }
}
