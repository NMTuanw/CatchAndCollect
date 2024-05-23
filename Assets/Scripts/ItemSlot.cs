// using System;
// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;

// public class ItemSlot : MonoBehaviour, IPointerClickHandler
// {
//     // ITEM DATA
//     public string itemName;
//     public Sprite itemIcon;
//     public int quantity;
//     public bool isFull;
//     public string itemDescription;

//     [SerializeField] 
//     private int maxNumberOfItemsSlotCanHold;

//     // ITEM SLOT

//     [SerializeField] private TextMeshProUGUI quantityText;

//     [SerializeField] private Image itemImage;

//     // ITEM DESCRIPTION SLOT
//     [SerializeField] private Image itemDescriptionImage;
//     [SerializeField] private TextMeshProUGUI itemDescriptionNameText;
//     [SerializeField] private TextMeshProUGUI itemDescriptionText;

//     [SerializeField] private Sprite emptySlotIcon;
    

//     public GameObject selectedSlot;

//     public bool isSlotSelected;

//     const string INVENTORYCANVAS = "InventoryCanvas";
//     private InventoryManager inventoryManager;

//     private void Start() {
//         inventoryManager = GameObject.Find(INVENTORYCANVAS).GetComponent<InventoryManager>();
//     }

//     public int AddItem(string itemName, Sprite itemIcon, int quantity, string itemDescription) // AddItemToSlot
//     {
//         // Check to see if the slot is already full
//         if (isFull)
//             return quantity;

//         // Update Item Data
//         this.itemName = itemName;

//         this.itemIcon = itemIcon;
//         itemImage.sprite = itemIcon;

//         this.itemDescription = itemDescription;

//         // Update Quantity
//         this.quantity += quantity;

//         if (this.quantity >= maxNumberOfItemsSlotCanHold)
//         {
//             quantityText.text = maxNumberOfItemsSlotCanHold.ToString();
//             quantityText.enabled = true;
//             isFull = true;

//             // Return LeftOvers
//             int extraItems = this.quantity - maxNumberOfItemsSlotCanHold;
//             this.quantity = maxNumberOfItemsSlotCanHold;
//             return extraItems;
//         }

//         // Update Quantity Text
//         quantityText.text = this.quantity.ToString();
//         quantityText.enabled = true;

//         return 0;
//     }

//     public void OnPointerClick(PointerEventData eventData)
//     {
//         if (eventData.button == PointerEventData.InputButton.Left)
//         {
//             OnLeftClick();
//         }

//         if (eventData.button == PointerEventData.InputButton.Right)
//         {
//             OnRightClick();
//         }
//     }

//     public void OnLeftClick()
//     {
//         /////~~~~~~~~~~
//         if (isSlotSelected)
//         {
//             bool usable = inventoryManager.UseItem(itemName);
//             if (usable)
//             {
//                 this.quantity -= 1;
//                 quantityText.text = this.quantity.ToString();
//                 if (this.quantity <= 0)
//                     EmptySlot();
//             }
//         }

//         else {
//             inventoryManager.DeselectAllSlots();
//             selectedSlot.SetActive(true);
//             isSlotSelected = true;

//             itemDescriptionImage.sprite = itemIcon; // loi item icon
//             itemDescriptionNameText.text = itemName;
//             itemDescriptionText.text = itemDescription;

//             if (itemDescriptionImage.sprite == null)
//                 itemDescriptionImage.sprite = emptySlotIcon;
//         }
//     }

//     private void EmptySlot()
//     {
//         isFull = false;
//         quantityText.enabled = false;
//         itemImage.sprite = emptySlotIcon;
//         itemDescription = "";
//         itemName = "";

//         itemDescriptionImage.sprite = emptySlotIcon;
//         itemDescriptionNameText.text = "";
//         itemDescriptionText.text = "";
//     }

//     public void OnRightClick()
//     {
//         if (this.quantity > 0)
//         {
//             // Create new Item
//             GameObject itemToDrop = new GameObject(itemName);
//             Item newItem = itemToDrop.AddComponent<Item>();
//             newItem.quantity = 1;
//             newItem.itemName = itemName;
//             newItem.itemIcon = itemIcon;
//             newItem.itemDescription = itemDescription;

//             // Create and modify the SR
//             SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
//             sr.sprite = itemIcon;
//             sr.sortingOrder = 5;

//             // Add Collider
//             BoxCollider2D itemToDropCollider = itemToDrop.AddComponent<BoxCollider2D>();
//             itemToDropCollider.isTrigger = true;

//             // Add Rigidbody
//             Rigidbody2D itemToDropRigidBody2D = itemToDrop.AddComponent<Rigidbody2D>();

//             // Set position
//             itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(2, 0, 0);
//             itemToDrop.transform.localScale = new Vector3(10f, 10f, 10f);
            
//             // Subtract the item
//             this.quantity -= 1;
//             quantityText.text = this.quantity.ToString();
//             if (this.quantity <= 0)
//                 EmptySlot();
//         }
//     }
// }
