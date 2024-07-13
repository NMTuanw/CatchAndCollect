using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerSkinSlot : MonoBehaviour, IPointerClickHandler
{
    [Header("Reference")]
    public SkinSO skinSO;

    [Header("Player Skin Slot")]
    public Image playerSkinSlotImage;
    public GameObject selectedSlot;
    public Image playerUI_Skin;
    public bool isSlotSelected;

    private static PlayerSkinSlot currentSelectedSlot; //  chia sẻ giữa tất cả các instance của PlayerSkinSlot.

    void Start()
    {
        ChangePlayerSkinSlotImage();
    }
    private void ChangePlayerSkinSlotImage()
    {
        playerSkinSlotImage.sprite = skinSO.skinSprite;
        playerUI_Skin.sprite = playerSkinSlotImage.sprite;
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
    }
    private void ChangeCurrentSlot()
    {
        if (currentSelectedSlot != null)
        {
            currentSelectedSlot.selectedSlot.SetActive(false);
            currentSelectedSlot.isSlotSelected = false;
        }

        currentSelectedSlot = this;
        isSlotSelected = true;
        selectedSlot.SetActive(true);
        playerUI_Skin.sprite = playerSkinSlotImage.sprite;
        
        SelectSkin();
    }

    private void SelectSkin()
    {
        if (skinSO.isUnlock)
        {
            SkinManager.instance.ChangeSkin(skinSO);
        }
    }
}
