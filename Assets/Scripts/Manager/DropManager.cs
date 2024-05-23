using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField] private GameObject[] probPrefab;
    [SerializeField] private float probSpawnTime;

    [Header("Prob Spawn Position For X Axis")]

    [SerializeField] private int minSpawnPositionX;
    [SerializeField] private int maxSpawnPositionX;
    private void Start() {
        InvokeRepeating("SpawnProb", 3, probSpawnTime);
    }

    private void SpawnProb()
    {
        int randSpawnPositionX = Random.Range(minSpawnPositionX, maxSpawnPositionX);
        Vector2 spawnPositionX = new Vector2(randSpawnPositionX, transform.position.y);

        int randProbPrefabIndex = Random.Range(0, probPrefab.Length);
        Instantiate(probPrefab[randProbPrefabIndex], spawnPositionX, Quaternion.identity);
    }
}
