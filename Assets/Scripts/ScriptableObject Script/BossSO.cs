using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss SO")]
public class BossSO : ScriptableObject
{
    public string bossName;

    public Sprite bossSprite;

    public int bossHealth;
    public int numberBoss;

    [TextArea]
    public string itemDescription;
}
