using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookmarkManager : MonoBehaviour
{
    [Header("Reference")]
    public GameObject[] bookmarkPages;

    [Header("Buttons")]
    public Button collectButton;
    public Button obstacleButton;

    private void Start()
    {
        SwitchBookmark(0);
        
        collectButton.onClick.AddListener(() => SwitchBookmark(0));
        obstacleButton.onClick.AddListener(() => SwitchBookmark(1));
    }

    private void SwitchBookmark(int index){
        for (int i = 0; i < bookmarkPages.Length; i++)
        {
            bookmarkPages[i].SetActive(false);
        }

        if (index >= 0 && index < bookmarkPages.Length)
        {
            bookmarkPages[index].SetActive(true);
        }
    }
}
