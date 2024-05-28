using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookUI : MonoBehaviour
{
    public void ShowBookUI()
    {
        gameObject.SetActive(true);
    }

    public void HideBookUI()
    {
        gameObject.SetActive(false);
    }
}
