using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "CharacterSO")]
public class CharacterSO : ScriptableObject 
{
    [Header("Item Stats (changeable)")]
    public string characterName;
    public int characterHealth;
    public int characterSpeed;
    public Color characterColor;
    public Sprite characterIcon;

    [TextArea]
    public string characterDescription;
}
