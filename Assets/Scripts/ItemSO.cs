using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ItemSO")]
public class ItemSO : ScriptableObject 
{
    public string itemName;

    public int sellPrice;

    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public bool UseItem()
    {
        if (statToChange == StatToChange.sellable)
        {
            // PlayerHealth playerHealth = GameObject.Find("HealthManager").GetComponent<PlayerHealth>();
            // if (playerHealth.health == playerHealth.maxHealth)
            // {
            //     return false;
            // }
            // else {
            //     playerHealth.ChangeHealth(amountToChangeStat);
            //     return true;
            // }
            // Debug.Log("Item sell for " + amountToChangeStat);
        }
        return false;
    }

    // public void SellItem()
    // {
    //     if (statToChange == StatToChange.sellable)
    //     {
    //         GameObject.Find("CoinManager").GetComponent<PlayerCoin>().ChangeCoin(amountToChangeStat);
    //     }
    // }

    public enum StatToChange
    {
        none,
        health, 
        mana,
        sellable
    }
}

