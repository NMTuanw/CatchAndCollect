using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [Header("Reference")]
    public SkinSO skinSO;

    [Header("Shop UI")]
    public TextMeshProUGUI skinName;
    public Image skinImage;
    public TextMeshProUGUI skinPrice;
    public TextMeshProUGUI skinDescription;

    public GameObject shopButtonUI;
    public GameObject ownedButtonUI;
    public Button skinButton;
    public Button ownedButton;
    void Start()
    {
        skinButton.onClick.AddListener(() => OnSkinButtonClick());
        ownedButton.onClick.AddListener(() => OnSkinButtonClick());
    }
    private void Update()
    {
        UpdateShopSlotUI();
    }

    private void UpdateShopSlotUI()
    {
        skinName.text = skinSO.skinName;
        skinImage.sprite = skinSO.skinSprite;
        skinPrice.text = skinSO.skinPrice.ToString();
        skinDescription.text = skinSO.skinDescription;
        
        if (skinSO.isUnlock)
        {
            shopButtonUI.SetActive(false);
            ownedButtonUI.SetActive(true);
        } else {
            shopButtonUI.SetActive(true);
            ownedButtonUI.SetActive(false);           
        }
    }

    private void OnSkinButtonClick()
    {
        if (!skinSO.isUnlock)
        {
            PurchaseSkin(skinSO);
        }
        else
        {
            ChangeSkin(skinSO);
        }
    }

    private void PurchaseSkin(SkinSO skinToPurchase)
    {
        if (CoinManager.instance.coin >= skinToPurchase.skinPrice)
        {
            CoinManager.instance.RemoveCoin(skinToPurchase.skinPrice);
            skinToPurchase.isUnlock = true;
        }
    }

    private void ChangeSkin(SkinSO newSkin)
    {
        SkinManager.instance.ChangeSkin(newSkin);
        Debug.Log("Skin changed to: " + newSkin.skinName);
    }
}
