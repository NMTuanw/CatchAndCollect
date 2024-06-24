using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameSettingsUI : MonoBehaviour // , IPointerClickHandler
{
    public static GameSettingsUI Instance {get; private set;}

    [Header("Buttons")]
    [SerializeField] private Button settingButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button quitButton;

    private void Awake() {
        Instance = this;

        settingButton.onClick.AddListener(() => {
            KitchenGameManager.Instance.TogglePauseGame();
        });
        closeButton.onClick.AddListener(() => {
            KitchenGameManager.Instance.TogglePauseGame();
        });
        quitButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.LevelSelectScene);
        });
    }

    private void Start() {
        KitchenGameManager.Instance.OnGameOptionOpen += KitchenGameManager_OnGameOptionOpen;
        KitchenGameManager.Instance.OnGameOptionClose += KitchenGameManager_OnGameOptionClose;
        Hide();
    }

    private void KitchenGameManager_OnGameOptionOpen(object sender, EventArgs e)
    {
        Show();
    }
    private void KitchenGameManager_OnGameOptionClose(object sender, EventArgs e)
    {
        Hide();
    }
    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }


}

