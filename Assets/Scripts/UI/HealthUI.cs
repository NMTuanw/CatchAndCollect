using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI healthText;
    public Image healthImage;

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
        UpdateUI();

        // Tìm lại player trong trường hợp bị mất tham chiếu
        FindPlayerReferences();
    }

    private void UpdateUI()
    {
        healthText.text = "" + HealthManager.instance.health;
        if (spriteRenderer != null)
        {
            healthImage.sprite = spriteRenderer.sprite;
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
