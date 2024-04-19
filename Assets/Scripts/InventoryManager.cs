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

    public void AddItem(string itemName, Sprite itemIcon, int quantity, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, itemIcon, quantity, itemDescription); // AddItemToSlot
                return;
            }
        } 
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
