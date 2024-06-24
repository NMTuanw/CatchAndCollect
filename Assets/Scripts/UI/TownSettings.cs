using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TownSettings : MonoBehaviour // , IPointerClickHandler
{
    public static TownSettings Instance {get; private set;}

    [Header("Buttons")]
    [SerializeField] private Button settingButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button mainMenuButton;


    private void Awake() {
        Instance = this;

        settingButton.onClick.AddListener(() => {
            Show();
        });
        closeButton.onClick.AddListener(() => {
            Hide();
        });
        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });

    }

    private void Start() {
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

