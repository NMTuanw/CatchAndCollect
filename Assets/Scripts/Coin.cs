using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event EventHandler OnCoinCollect;
    public ItemSO itemSO;
    [SerializeField] private int coinValue;
    [SerializeField] private float droppingSpeed;

    private void Update() {
        transform.Translate(Vector2.down * droppingSpeed * Time.deltaTime);
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
            CoinManager.instance.AddCoin(coinValue);
            Debug.Log("Prob touched the player.");
            OnCoinCollect?.Invoke(this, EventArgs.Empty);

        }
    }
}
