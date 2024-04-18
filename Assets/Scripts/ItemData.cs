using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;

    public int sellPrice;
    public int buyPrice;

    public int defaultMaxStack = 20;
    [TextArea]
    public string itemDescription;
}
