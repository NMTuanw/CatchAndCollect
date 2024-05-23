using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeUI : MonoBehaviour
{
    public GameObject volumeUI;

    void Awake()
    {
        volumeUI = GameObject.Find("VolumeUI");
        Hide();
    }
    public void Show()
    {
        volumeUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Hide()
    {
        volumeUI.SetActive(false);
        Time.timeScale = 1f;

    }
}
