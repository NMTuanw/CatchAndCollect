using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    void Update()
    {
        UpdateCoinTextUI();
    }
    private void UpdateCoinTextUI()
    {
        if (coinText != null)
        {
            coinText.text = "" + CoinManager.instance.coin;
        }
    }
}
