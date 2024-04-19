using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    private Dictionary<ItemData, InventoryItem> itemDictionary;
    public List<InventoryItem> inventory { get; private set;}

    private void Awake() {
        inventory = new List<InventoryItem>();
        itemDictionary = new Dictionary<ItemData, InventoryItem>();

        Instance = this;
    }

    public void AddItem(ItemData itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
        }
    }


    public void RemoveItem(ItemData itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                itemDictionary.Remove(itemData);
            }
        }
    }

    public InventoryItem Get(ItemData itemData){
        if (itemDictionary.TryGetValue(itemData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }
}
