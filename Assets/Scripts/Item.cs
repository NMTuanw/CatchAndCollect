using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float droppingSpeed;

    [SerializeField] public string itemName;

    [SerializeField] public Sprite itemIcon;

    [SerializeField] public int quantity;

    [TextArea]
    [SerializeField] public string itemDescription;

    public ItemSO itemSO;
    private void Update() {
        transform.Translate(Vector2.down * droppingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            HealthManager.instance.RemoveHealth(1);
            Debug.Log("Prob touched the ground.");
        }

        if (other.gameObject.CompareTag("Player"))
        {   
            Destroy(gameObject);
            itemSO.collectedNumber += 1;
            Debug.Log("Prob touched the player.");
        }
    }
}
