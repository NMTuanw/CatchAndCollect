using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{   
    public static SkinManager instance;
    public SkinSO[] skinSOArray;
    public SpriteRenderer playerSpriteRenderer;

    //private const string SelectedSkinKey = "SelectedSkin";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        GameObject player = GameObject.FindWithTag("Player");
        playerSpriteRenderer = player.GetComponentInChildren<SpriteRenderer>();

        LoadSkinStates();
    }
    private void LoadSkinStates()
    {
        foreach (var skin in skinSOArray)
        {
            skin.isUnlock = PlayerPrefs.GetInt(skin.skinName + "_isUnlock", 0) == 1;
            skin.isSelect = PlayerPrefs.GetInt(skin.skinName + "_isSelect", 0) == 1;

            if (skin.isSelect)
            {
                playerSpriteRenderer.sprite = skin.skinSprite;
            }
        }
    }

    public void ChangeSkin(SkinSO skinSO)
    {
        if (!skinSO.isUnlock)
        {
            Debug.LogError("Skin is not unlocked");
            return;
        }

        playerSpriteRenderer.sprite = skinSO.skinSprite;
        skinSO.isSelect = true;

        foreach (var skin in skinSOArray)
        {
            if (skin != skinSO)
            {
                skin.isSelect = false;
                PlayerPrefs.SetInt(skin.skinName + "_isSelect", 0);
            }
        }

        PlayerPrefs.SetString("SelectedSkin", skinSO.skinName);
        PlayerPrefs.SetInt(skinSO.skinName + "_isSelect", 1);
        PlayerPrefs.Save();
    }

    public Sprite GetSavedSkin()
    {
        string spriteName = PlayerPrefs.GetString("SelectedSkin");
        foreach (var skinSO in skinSOArray)
        {
            if (skinSO.skinName == spriteName)
            {
                return skinSO.skinSprite;
            }
        }
        return null;
    }
}
