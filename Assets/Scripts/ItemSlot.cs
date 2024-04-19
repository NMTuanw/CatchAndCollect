using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // ITEM DATA
    public string itemName;

    public Sprite itemIcon;

    public int quantity;

    public bool isFull;

    public string itemDescription;
    // ITEM SLOT

    [SerializeField] private TextMeshProUGUI quantityText;

    [SerializeField] private Image itemImage;

    // ITEM DESCRIPTION SLOT
    [SerializeField] private Image itemDescriptionImage;
    [SerializeField] private TextMeshProUGUI itemDescriptionNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    

    public GameObject selectedSlot;

    public bool isSlotSelected;

    const string INVENTORYCANVAS = "InventoryCanvas";
    private InventoryManager inventoryManager;

    private void Start() {
        inventoryManager = GameObject.Find(INVENTORYCANVAS).GetComponent<InventoryManager>();
    }

    public void AddItem(string itemName, Sprite itemIcon, int quantity, string itemDescription) // AddItemToSlot
    {
        this.itemName = itemName;
        this.itemIcon = itemIcon;
        this.quantity = quantity;
        this.itemDescription = itemDescription;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        selectedSlot.SetActive(true);
        isSlotSelected = true;

        itemDescriptionImage.sprite = itemIcon;
        itemDescriptionNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
    }

    public void OnRightClick()
    {

    }
}
