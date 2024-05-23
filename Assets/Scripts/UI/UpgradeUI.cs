using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [Header("Upgrade Button")]
    public Button healthButton;
    public Button speedButton;
    public Button dashSpeedButton;
    public Button dashDurationButton;
    public Button dashCooldownButton;

    [Header("Other")]
    public Button resetButton; // Nút để reset chỉ số
    public Button loadGameSceneButton;

    [Header("Reference Script")]
    public UpgradeSystem upgradeSystem;

    void Start()
    {
        healthButton.onClick.AddListener(upgradeSystem.UpgradeHealth);
        speedButton.onClick.AddListener(upgradeSystem.UpgradeSpeed);
        dashSpeedButton.onClick.AddListener(upgradeSystem.UpgradeDashSpeed);
        dashDurationButton.onClick.AddListener(upgradeSystem.UpgradeDashDuration);
        dashCooldownButton.onClick.AddListener(upgradeSystem.UpgradeDashCooldown);

        resetButton.onClick.AddListener(upgradeSystem.ResetCharacterStats);

        loadGameSceneButton.onClick.AddListener(() => {
            LoadGameScene("GameScene2");
        });
    }

    private void LoadGameScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
