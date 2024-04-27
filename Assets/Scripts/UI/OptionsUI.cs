using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] 
    private GameObject optionsUI;

    [SerializeField] 
    private Button closeOptionsUIButton;

    [SerializeField] 
    private Button resumeButton;
    [SerializeField] 
    private Button volumeButton;
    [SerializeField] 
    private Button quitButton;
    void Awake()
    {
        Hide();
    }

    private void Update()
    {
        closeOptionsUIButton.onClick.AddListener(() => {
            Hide();
        });

        resumeButton.onClick.AddListener(() => {
            Hide();
        });

        volumeButton.onClick.AddListener(() =>
        {
            // open volume ui
        });

        quitButton.onClick.AddListener(() =>
        {
            // return to main menu or other scene
        });
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        Show();
    }

    private void Show(){
        optionsUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Hide(){
        optionsUI.SetActive(false);
        Time.timeScale = 1f;
    }

}
