using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DashSkillCooldownUI : MonoBehaviour
{
    [Header("Dash")]
    public Image dashFillImage;
    private CharacterStats characterStats;

    private Dash dashScript;
    private float cooldownTimer = 0f;
    private bool isCooldown = false;

    private void Start()
    {
        dashScript = FindObjectOfType<Dash>();
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();


        dashFillImage.fillAmount = 0;
        
        cooldownTimer = characterStats.dashCooldown;

    }
    
    private void Update()
    {
        UpdateSkillUI();
    }

    private void UpdateSkillUI()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isCooldown)
        {
            StartCooldown();
        }

        if (isCooldown)
        {
            SkillCooldownUI();
        }
    }

    private void StartCooldown()
    {
        isCooldown = true;
        cooldownTimer = characterStats.dashCooldown;
    }

    private void SkillCooldownUI()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
        {
            cooldownTimer = 0;
            isCooldown = false;
        }

        float fillAmount = Mathf.Clamp01(cooldownTimer / characterStats.dashCooldown);
        dashFillImage.fillAmount = fillAmount;
    }
}