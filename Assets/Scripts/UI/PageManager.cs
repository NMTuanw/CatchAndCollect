using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    [Header("Reference")]
    public GameObject[] slotPages;

    [Header("SwitchPage UI")]
    public Button backPageButton;
    public TextMeshProUGUI pageNumberText;
    public Button nextPageButton;

    [Header("Page Number")]
    private int currentPageIndex = 0;

    void Start()
    {
        UpdatePage();

        // Gán sự kiện cho các nút
        nextPageButton.onClick.AddListener(OnNextPage);
        backPageButton.onClick.AddListener(OnBackPage);
    }

    void Update()
    {
        UpdatePageNumber();
    }

    private void UpdatePage()
    {
        for (int i = 0; i < slotPages.Length; i++)
        {
            slotPages[i].SetActive(false);
        }

        if (currentPageIndex >= 0 && currentPageIndex < slotPages.Length)
        {
            slotPages[currentPageIndex].SetActive(true);
        }

        backPageButton.interactable = currentPageIndex > 0;
        nextPageButton.interactable = currentPageIndex < slotPages.Length - 1;
    }

    private void OnNextPage()
    {
        if (currentPageIndex < slotPages.Length - 1)
        {
            currentPageIndex++;
            UpdatePage();
        }
    }

    private void OnBackPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            UpdatePage();
        }
    }

    private void UpdatePageNumber()
    {
        pageNumberText.text = (currentPageIndex + 1) + "/" + slotPages.Length;
    }
}
