using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
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
            HealthManager.instance.RemoveHealth(5);
            Debug.Log("Obstacle touched the player.");
        }
    }
}
