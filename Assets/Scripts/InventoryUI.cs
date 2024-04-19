using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] 
    private Image icon;

    [SerializeField] 
    private TextMeshProUGUI label;

    [SerializeField] 
    private TextMeshProUGUI stackLabel;

    [SerializeField] 
    private GameObject stackObj;

    public void Set(InventoryItem inventoryItem)
    {
        icon.sprite = inventoryItem.inventoryItemData.icon;
        label.text = inventoryItem.inventoryItemData.name;

        if(inventoryItem.stackSize <= 1)
        {
            stackObj.SetActive(false);
            return;
        }

        stackLabel.text = inventoryItem.stackSize.ToString();

    
    }



}
