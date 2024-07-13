using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [Header("Variable")]
    public int coin;
    [SerializeField] private int coinSpended;

    void Awake()
    { 
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            LoadCoins();
        }
        else
        {
            Destroy(gameObject);
        }
        LoadCoins();
    }

    private void OnApplicationQuit()
    {
        SaveCoins(); // Lưu số coin khi thoát game
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        SaveCoins();
    }

    public void RemoveCoin(int amount)
    {
        coin -= amount;
        SaveCoins();
    }

    public void SpendCoins(int amount)
    {
        if (coin >= amount)
        {
            coin -= amount;
            coinSpended += amount;
            SaveCoins();
        }
        else
        {
            Debug.Log("Not enough coins!");
            return;
        }
    }

    public void ResetCoins()
    {
        coin += coinSpended;
        coinSpended = 0;
        SaveCoins();
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt("Coin", coin); // Lưu số coin vào PlayerPrefs
        PlayerPrefs.SetInt("CoinSpended", coinSpended); 
        PlayerPrefs.Save();
    }

    public void LoadCoins()
    {
        coin = PlayerPrefs.GetInt("Coin", 0); // Neu khong ton tai thi se load ve default value la 0
        coinSpended = PlayerPrefs.GetInt("CoinSpended", 0); 
    }
}
