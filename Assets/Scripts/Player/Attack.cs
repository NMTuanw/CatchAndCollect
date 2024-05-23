using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int maxEnergy;
    public int currentEnergy;

    public GameObject projectilePrefab;

    public Transform projectileSpawnPoint;

    private void Start()
    {
        currentEnergy = 0;
        projectileSpawnPoint = transform.Find("projectileSpawnPoint");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentEnergy >= maxEnergy)
        {
            Shoot();
            currentEnergy = 0;
        }

        MaxEnergyUI();
    }

    public void CollectEnergy(int amount)
    {
        currentEnergy = Mathf.Min(currentEnergy + amount, maxEnergy);
    }

    private void Shoot()
    {
        Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    }

    private void MaxEnergyUI()
    {
        if (currentEnergy >= maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
    }
}
