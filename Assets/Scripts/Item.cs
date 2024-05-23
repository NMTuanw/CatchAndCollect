using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO itemSO;

    public Attack attack;
    void Awake()
    {
        attack = GameObject.Find("Player").GetComponent<Attack>();
    }
    
    private void Update() {
        transform.Translate(Vector2.down * itemSO.droppingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            //HealthManager.instance.RemoveHealth(1);
            Debug.Log("Prob touched the ground.");
        }

        if (other.gameObject.CompareTag("Player"))
        {   
            Destroy(gameObject);
            itemSO.collectedNumber += 1;
            attack.currentEnergy += itemSO.energyWhenCollect;
            Debug.Log("Prob touched the player.");
        }
    }
}
