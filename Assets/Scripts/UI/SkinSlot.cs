using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinSlot : MonoBehaviour
{
    [Header("Reference")]
    public SkinSO skinSO;

    [Header("Skin Slot UI")]
    public TextMeshProUGUI skinName;
    public Image skinImage;
    public TextMeshProUGUI skinPrice;
    public TextMeshProUGUI skinDescription;

    [Header("Skin Button UI")]
    public GameObject skinButtonUI;
    public Button skinButton;

    
    [Header("Owned Button UI")]
    public GameObject ownedButtonUI;
    public Button ownedButton;

    public TextMeshProUGUI ownedButtonText;
    void Start()
    {
        skinButton.onClick.AddListener(() => OnSkinButtonClick());
        ownedButton.onClick.AddListener(() => OnSkinButtonClick());

        skinSO.isUnlock = PlayerPrefs.GetInt(skinSO.skinName + "_isUnlock", 0) == 1;
        skinSO.isSelect = PlayerPrefs.GetInt(skinSO.skinName + "_isSelect", 0) == 1;
    }
    private void Update()
    {
        UpdateSkinSlotUI();
    }

    private void UpdateSkinSlotUI()
    {
        skinName.text = skinSO.skinName;
        skinImage.sprite = skinSO.skinSprite;
        skinPrice.text = skinSO.skinPrice.ToString();
        skinDescription.text = skinSO.skinDescription;
        
        if (skinSO.isUnlock)
        {
            skinButtonUI.SetActive(false);
            ownedButtonUI.SetActive(true);
        } else {
            skinButtonUI.SetActive(true);
            ownedButtonUI.SetActive(false);           
        }

    }

    private void OnSkinButtonClick()
    {
        if (!skinSO.isUnlock)
        {
            PurchaseSkin(skinSO);
        }
        else {
            Debug.Log("Skin is Unlocked");
            return;
        }
    }

    private void PurchaseSkin(SkinSO skinToPurchase)
    {
        int coin = CoinManager.instance.coin;
        int skinPrice = skinToPurchase.skinPrice;

        if (coin >= skinPrice)
        {
            CoinManager.instance.RemoveCoin(skinPrice);
            skinToPurchase.isUnlock = true;

            PlayerPrefs.SetInt(skinToPurchase.skinName + "_isUnlock", 1);
            PlayerPrefs.Save();
        }
    }
}
