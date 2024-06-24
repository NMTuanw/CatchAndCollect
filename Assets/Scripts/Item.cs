using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static event EventHandler OnItemCollect;
    public ItemSO itemSO;
    
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
            ScoreManager.instance.AddScore(itemSO.gameScore);
            Debug.Log("Prob touched the player.");

            OnItemCollect?.Invoke(this, EventArgs.Empty);
        }
    }
}
