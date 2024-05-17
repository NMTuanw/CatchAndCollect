using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    private void Start()
    {
        health = numOfHearts;
    }
    private void Update() {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHearts;
            } else {
                hearts[i].sprite = emptyHearts;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
    
}
