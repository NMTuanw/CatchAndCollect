using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "LevelSO")]
public class LevelSO : ScriptableObject
{
    public int levelIndex;
    public string levelName;
    public Sprite levelImage;

    public int highScore; // bo di
    public int levelStars; // bo
    
}
