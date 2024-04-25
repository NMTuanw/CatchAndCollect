using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // public ItemData referenceItem;

    const string INVENTORYCANVAS = "InventoryCanvas";
    [SerializeField] private float droppingSpeed;

    [SerializeField] public string itemName;

    [SerializeField] public Sprite itemIcon;

    [SerializeField] public int quantity;

    [TextArea]
    [SerializeField] public string itemDescription;

    private InventoryManager inventoryManager;

    private HealthManager healthManager;
    private void Start() {
        inventoryManager = GameObject.Find(INVENTORYCANVAS).GetComponent<InventoryManager>(); 
        healthManager = GameObject.Find("HealthManager").GetComponent<HealthManager>();
    }
    private void Update() {
        transform.Translate(Vector2.down * droppingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            healthManager.RemoveHealth(1);
            Debug.Log("Prob touched the ground.");
        }

        if (other.gameObject.CompareTag("Player"))
        {   
            int leftOverItems = inventoryManager.AddItem(itemName, itemIcon, quantity, itemDescription);
            if (leftOverItems <= 0)
            {
                Destroy(gameObject);
            } else {
                quantity = leftOverItems;
            }
            Debug.Log("Prob touched the player.");
        }
    }
}
