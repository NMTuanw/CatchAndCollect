using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    public SpriteRenderer playerSpriteRenderer;

    void Awake()
    {
        playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void Start()
    {
        //LoadSkin();
    }

    private void LoadSkin()
    {
        Sprite savedSkin = SkinManager.instance.GetSavedSkin();
        if (savedSkin != null)
        {
            playerSpriteRenderer.sprite = savedSkin;
        }
    }
}
