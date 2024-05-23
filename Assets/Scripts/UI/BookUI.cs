using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookUI : MonoBehaviour
{
    public TextMeshProUGUI pumpkinCollected;

    public ItemSO itemSO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pumpkinCollected.text = itemSO.collectedNumber.ToString();
    }
}
