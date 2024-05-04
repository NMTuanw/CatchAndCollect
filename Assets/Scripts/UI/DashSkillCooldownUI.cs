using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DashSkillCooldownUI : MonoBehaviour
{
    [Header("Dash")]
    public Image dashCooldownImage;
    private Dash dashScript;
    private float cooldownTimer = 0f;
    private bool isCooldown = false;

    private void Start()
    {
        dashCooldownImage.fillAmount = 0;
        dashScript = FindObjectOfType<Dash>();

        if (dashScript != null)
        {
            cooldownTimer = dashScript.DashCooldown;
        }
        else
        {
            Debug.LogWarning("Dash script not found in the scene.");
        }
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
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0)
            {
                cooldownTimer = 0;
                isCooldown = false;
            }

            float fillAmount = Mathf.Clamp01(cooldownTimer / dashScript.DashCooldown);
            dashCooldownImage.fillAmount = fillAmount;
        }
    }

    private void StartCooldown()
    {
        isCooldown = true;
        cooldownTimer = dashScript.DashCooldown;
    }
}