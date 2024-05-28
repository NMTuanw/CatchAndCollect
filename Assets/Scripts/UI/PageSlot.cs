using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class PageSlot : MonoBehaviour, IPointerClickHandler
{
    [Header("Reference")]
    public ItemSO itemSO;

    [Header("Page Slot")]
    public Image pageSlotBackground;
    public Image pageSlotImage;

    public GameObject selectedSlot;

    [Header("Page Slot Description")]
    public Image pageSlotDescriptionImageBackground;
    public Image pageSlotDescriptionImage;
    public TextMeshProUGUI pageSlotName;
    public TextMeshProUGUI pageSlotCollected;
    public Image pageSlotDescriptionBackground;
    public TextMeshProUGUI pageSlotDescription;

    [SerializeField] private Sprite emptySlotIcon;

    private static PageSlot currentSelectedSlot; //  chia sẻ giữa tất cả các instance của FruitPageSlot.

    public bool isSlotSelected;
    void Start()
    {
        EmptySlot();
        ChangePageSlotImage();
    }
    private void ChangePageSlotImage()
    {
        pageSlotImage.sprite = itemSO.itemIcon;
        pageSlotBackground.color = itemSO.itemColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    private void OnLeftClick()
    {
        ChangeCurrentSlot();
        ChangeDescription();
        ChangeTextColor();
    }

    private void ChangeCurrentSlot()
    {
        if (currentSelectedSlot != null)
        {
            currentSelectedSlot.selectedSlot.SetActive(false);
            currentSelectedSlot.isSlotSelected = false;
        }

        currentSelectedSlot = this;
        selectedSlot.SetActive(true);
        isSlotSelected = true;
    }

    private void ChangeDescription()
    {
        pageSlotDescriptionImageBackground.color = itemSO.itemColor;
        pageSlotDescriptionImage.sprite = itemSO.itemIcon; 
        pageSlotName.text = itemSO.itemName.ToString();
        pageSlotCollected.text = "Collected: " + itemSO.collectedNumber.ToString();
        pageSlotDescriptionBackground.color = itemSO.itemColor;
        pageSlotDescription.text = itemSO.itemDescription;       

        if (pageSlotDescriptionImage.sprite == null)
            pageSlotDescriptionImage.sprite = emptySlotIcon;
    }
    private void ChangeTextColor()
    {
        pageSlotName.color = itemSO.itemColor;
        pageSlotCollected.color = itemSO.itemColor;
    }

    private void EmptySlot()
    {
        pageSlotDescriptionImageBackground.color = itemSO.itemColor;
        pageSlotDescriptionImage.sprite = emptySlotIcon; 
        pageSlotName.text = "";
        pageSlotCollected.text = "";
        pageSlotDescriptionBackground.color = itemSO.itemColor;
        pageSlotDescription.text = "";    
    }

    
}
