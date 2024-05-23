using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ItemSO")]
public class ItemSO : ScriptableObject 
{
    public string itemName;

    public float droppingSpeed;

    public Sprite itemIcon;

    public int collectedNumber;
    public int quantity;

    [TextArea]
    public string itemDescription;
}

