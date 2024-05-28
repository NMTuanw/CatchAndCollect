using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookmarkManager : MonoBehaviour
{
    [Header("Reference")]
    public GameObject[] bookmarkPages;

    [Header("Buttons")]
    public Button fruitButton;
    public Button characterButton;
    public Button enemyButton;

    private void Start()
    {
        SwitchBookmark(0);
        
        fruitButton.onClick.AddListener(() => SwitchBookmark(0));
        characterButton.onClick.AddListener(() => SwitchBookmark(1));
        enemyButton.onClick.AddListener(() => SwitchBookmark(2));
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
