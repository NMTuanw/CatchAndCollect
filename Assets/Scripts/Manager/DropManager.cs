using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public GameObject prefab;
        public float spawnRate; // Tỉ lệ spawn của vật phẩm
    }

    public Item[] items; // Danh sách các vật phẩm và tỉ lệ spawn của chúng

    [SerializeField] private float probSpawnTime;

    [Header("Spawn Position For X Axis")]
    [SerializeField] private int minSpawnPositionX;
    [SerializeField] private int maxSpawnPositionX;
    [Header("Spawn Position For Y Axis")]
    [SerializeField] private int spawnPostionY;

    private void Start() {
        InvokeRepeating("SpawnItem", 3, probSpawnTime);
    }

    void SpawnItem()
    {
        // Tính tổng tỉ lệ spawn
        float totalRate = 0f;
        foreach (Item item in items)
        {
            totalRate += item.spawnRate;
        }

        // Chọn một giá trị ngẫu nhiên trong khoảng từ 0 đến tổng tỉ lệ spawn
        float randomValue = Random.Range(0, totalRate); 

        int randSpawnPositionX = Random.Range(minSpawnPositionX, maxSpawnPositionX);
        Vector2 spawnPositionX = new Vector2(randSpawnPositionX, spawnPostionY);

        // Tìm vật phẩm tương ứng với giá trị ngẫu nhiên
        float cumulativeRate = 0f; 
        foreach (Item item in items)
        {
            cumulativeRate += item.spawnRate;
            Debug.Log("cumulativeRate: " + cumulativeRate + " - "+ "item.spawnRate: " + item.spawnRate);
            if (randomValue <= cumulativeRate)
            {
                Instantiate(item.prefab, spawnPositionX, Quaternion.identity);
                break;
            }
        }
    }
}
