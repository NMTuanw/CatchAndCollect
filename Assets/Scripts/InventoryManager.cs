using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    const string INVENTORY = "Inventory";
    public GameObject inventoryMenu;
    private bool menuActivated;

    public ItemSlot[] itemSlot;

    private void Update()
    {
        HandleInventoryMenu();
    }

    private void HandleInventoryMenu()
    {
        if (Input.GetKeyDown(KeyCode.I) && menuActivated)
        {
            HideInventoryMenu();
        } else if (Input.GetKeyDown(KeyCode.I) && !menuActivated)
        {
            ShowInventoryMenu();
        }       
    }

    private void ShowInventoryMenu()
    {
        inventoryMenu.SetActive(true);
        menuActivated = true;

        Time.timeScale = 0;
    }

    private void HideInventoryMenu()
    {
        inventoryMenu.SetActive(false);
        menuActivated = false;

        Time.timeScale = 1;
    }

    public int AddItem(string itemName, Sprite itemIcon, int quantity, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, itemIcon, quantity, itemDescription); // AddItemToSlot
                if (leftOverItems > 0)
                    leftOverItems = AddItem(itemName, itemIcon, leftOverItems, itemDescription);


                    return leftOverItems;
            }
        } 
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedSlot.SetActive(false);
            itemSlot[i].isSlotSelected = false;
        }
    }
}
