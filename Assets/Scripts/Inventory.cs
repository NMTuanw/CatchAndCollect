using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxItems;
    [SerializeField] private int maxSlot = 20;
    [SerializeField] public List<ItemData> items;
    // public List<ItemData> items = new List<ItemData>();

    public bool AddItem(ItemData itemData)
    {
        items.Add(itemData);
        return true;
    }


    // Phương thức xóa vật phẩm khỏi kho đồ
    public void RemoveItem(ItemData item)
    {
        items.Remove(item);
    }
}
