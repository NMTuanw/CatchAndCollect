using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public void Show_UpgradeUI()
    {
        gameObject.SetActive(true);
    }

    public void Hide_UpgradeUI()
    {
        gameObject.SetActive(false);
    }
}
