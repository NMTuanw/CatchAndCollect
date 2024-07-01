using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AvatarUI : MonoBehaviour
{
    [Header("UI")]
    public Image avatarImage;

    [Header("Reference Script")]
    public CharacterStats characterStats;
    public SpriteRenderer spriteRenderer;


    private void Start()
    {
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        spriteRenderer = GameObject.Find("Player").GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateUIAvatar();

        FindPlayerReferences();
    }

    private void UpdateUIAvatar()
    {
        if (spriteRenderer != null)
        {
            avatarImage.sprite = spriteRenderer.sprite;
        }
    }

    private void FindPlayerReferences()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            spriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
        }
    }

}
