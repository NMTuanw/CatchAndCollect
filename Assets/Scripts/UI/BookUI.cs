using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookUI : MonoBehaviour
{
    [Header("UI Text")]
    public TextMeshProUGUI pumpkinCollected;

    [Header("UI Button")]

    [Header("Reference Script")]
    public ItemSO itemSO;
    private void Start()
    {
        
    }

    private void Update()
    {
        pumpkinCollected.text = itemSO.collectedNumber.ToString();
    }
}
