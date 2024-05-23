using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ItemSO")]
public class ItemSO : ScriptableObject 
{
    [Header("Item Stats (changeable)")]
    public string itemName;

    public float droppingSpeed;

    public int energyWhenCollect;

    public Sprite itemIcon;

    [Header("Collected (read-only)")]
    public int collectedNumber;
    public int quantity;


    [TextArea]
    public string itemDescription;
}

