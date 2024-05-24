using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public BossSO bossSO;
    // Boss Logic
    // Phase 1, Phase 2, ...
    [SerializeField] private SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        spriteRenderer.sprite = bossSO.bossSprite;
    }
}
