using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float droppingSpeed;

    private void Update() {
        transform.Translate(Vector2.down * droppingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {   
            Destroy(gameObject);
            CoinManager.instance.AddCoin(1);
            Debug.Log("Prob touched the player.");
        }
    }
}
