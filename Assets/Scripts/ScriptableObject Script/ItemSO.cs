using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Item SO")]
public class ItemSO : ScriptableObject 
{
    [Header("Item Stats")]
    public string itemName;

    public float droppingSpeed;

    public int gameScore;

    public Color itemColor;
    public Sprite itemIcon;

    [TextArea]
    public string itemDescription;
}

