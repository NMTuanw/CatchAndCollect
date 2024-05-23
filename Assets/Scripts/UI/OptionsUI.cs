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
    [SerializeField] private VolumeUI volumeUI;

    void Awake()
    {
        volumeUI = GameObject.Find("VolumeUIMenu").GetComponent<VolumeUI>();
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
            volumeUI.Show();
            Hide();
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

    public void Show(){
        optionsUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Hide(){
        optionsUI.SetActive(false);
        Time.timeScale = 1f;
    }

}
