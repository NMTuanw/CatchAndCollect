using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public ItemData inventoryItemData { get; private set; }

    public int stackSize {get; private set;}

    public InventoryItem (ItemData itemData)
    {
        inventoryItemData = itemData;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack(){
        stackSize--;
    }
}
