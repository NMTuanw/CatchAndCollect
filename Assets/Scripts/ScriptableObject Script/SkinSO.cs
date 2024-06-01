using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(menuName = "Skin SO")]
public class SkinSO : ScriptableObject
{
    public string skinName;
    public Sprite skinSprite;
    public int skinPrice;

    public bool isUnlock;
    [TextArea]
    public string skinDescription;
    
}
