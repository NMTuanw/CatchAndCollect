using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public void Show_PlayerUI()
    {
        gameObject.SetActive(true);
    }

    public void Hide_PlayerUI()
    {
        gameObject.SetActive(false);
    }
}
