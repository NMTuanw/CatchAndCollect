using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager instance;

    public SkinSO currentSkin;
    public SkinSO[] availableSkins; // Danh sách các skin có sẵn trong shop

    public SpriteRenderer playerSpriteRenderer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject); // Giữ đối tượng này khi chuyển đổi cảnh
            FindPlayerSpriteRenderer();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void FindPlayerSpriteRenderer(){
        GameObject player = GameObject.FindWithTag("Player"); // Tìm đối tượng người chơi bằng tag
        if (player != null)
        {
            playerSpriteRenderer = player.GetComponentInChildren<SpriteRenderer>(); // Lấy thành phần SpriteRenderer từ đối tượng người chơi
            if (playerSpriteRenderer == null)
            {
                currentSkin.skinSprite = playerSpriteRenderer.sprite;
                Debug.LogError("SpriteRenderer not found on Player object!");
            }
        }
    }
    public void ChangeSkin(SkinSO newSkin)
    {
        playerSpriteRenderer.sprite = newSkin.skinSprite;
        currentSkin = newSkin;
    }

    public bool PurchaseSkin(SkinSO skinToPurchase)
    {
        if (CoinManager.instance.coin >= skinToPurchase.skinPrice)
        {
            CoinManager.instance.RemoveCoin(skinToPurchase.skinPrice);
            skinToPurchase.isUnlock = true;
            // Lưu trạng thái của skin, nếu cần
            return true;
        }
        else
        {
            Debug.Log("Not enough coins to purchase the skin!");
            return false;
        }
    }
}
