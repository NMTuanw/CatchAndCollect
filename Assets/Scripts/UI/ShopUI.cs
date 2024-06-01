using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public void Show_ShopUI()
    {
        gameObject.SetActive(true);
    }

    public void Hide_ShopUI()
    {
        gameObject.SetActive(false);
    }
}
