using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // public ItemData referenceItem;

    const string INVENTORYCANVAS = "InventoryCanvas";
    [SerializeField] private float droppingSpeed;

    [SerializeField] private string itemName;

    [SerializeField] private Sprite itemIcon;

    [SerializeField] private int quantity;

    [TextArea]
    [SerializeField] private string itemDescription;

    private InventoryManager inventoryManager;
    private void Start() {
        inventoryManager = GameObject.Find(INVENTORYCANVAS).GetComponent<InventoryManager>(); 
    }
    private void Update() {
        transform.Translate(Vector2.down * droppingSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Debug.Log("Prob touched the ground.");
        }

        if (other.gameObject.CompareTag("Player"))
        {   
            inventoryManager.AddItem(itemName, itemIcon, quantity, itemDescription);
            Destroy(gameObject);
            Debug.Log("Prob touched the player.");
        }
    }
}
