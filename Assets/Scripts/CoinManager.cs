using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [Header("Variable")]
    public int coin;

    [Header("UI")]
    public TextMeshProUGUI coinText;

    void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCoins();
        }
        else
        {
            Destroy(gameObject);
        }

        UpdateCoinTextUI();
    }

    private void OnApplicationQuit()
    {
        SaveCoins(); // Lưu số coin khi thoát game
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        UpdateCoinTextUI();
    }

    public void RemoveCoin(int amount)
    {
        coin -= amount;
    }

    public void SpendCoins(int amount)
    {
        if (coin >= amount)
        {
            coin -= amount;
            UpdateCoinTextUI();
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    void UpdateCoinTextUI()
    {
        if (coinText != null)
        {
            coinText.text = "X " + coin;
        }
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt("CoinCount", coin); // Lưu số coin vào PlayerPrefs
        PlayerPrefs.Save();
    }

    public void LoadCoins()
    {
        coin = PlayerPrefs.GetInt("CoinCount", 0); // Load số coin từ PlayerPrefs
        UpdateCoinTextUI();
    }
}
